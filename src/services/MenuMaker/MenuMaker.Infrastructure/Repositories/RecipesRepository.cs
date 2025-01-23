using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Mappers;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using MenuMaker.Infrastructure.Entities.Recipes;
using Recipe = MenuMaker.Infrastructure.Entities.Recipes.Recipe;
using MenuMaker.Infrastructure.Persistence;

namespace MenuMaker.Infrastructure.Repositories;
public class RecipesRepository : GenericRepository<Recipe, int, RecipesContext>, IRecipesRepository
{
    public RecipesRepository(RecipesContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Domain.Models.Recipes.Recipe>> GetAllRecipes()
    {
        var recipes = await GetAllAsync();
        return RecipeEntityMapper.MapToRecipeModelsList(recipes.ToList());
    }

    public async Task<Domain.Models.Recipes.Recipe> GetRecipe(int id)
    {
        var spec = new BaseSpecification<Recipe>(r => r.Id == id);
        spec.AddInclude(q =>
            q.Include(r => r.Ingredients)
                .ThenInclude(i => i.Grocery)
                .ThenInclude(g => g.Category)
            );
        var recipeEntity = (await FindWithSpecification(spec)).FirstOrDefault();
        if (recipeEntity == null)
        {
            return null;
        }
        return RecipeEntityMapper.MapToRecipeModel(recipeEntity);
    }

    public async Task<IEnumerable<Domain.Models.Recipes.Recipe>> GetRecipesWithFilter(RecipeFilter filter)
    {
        var spec = new BaseSpecification<Recipe>();
        if (filter.IncludeIngredients)
        {
            spec.AddInclude(q =>
                q.Include(r => r.Ingredients)
                    .ThenInclude(i => i.Grocery)
                    .ThenInclude(g => g.Category)
                );
        }
        spec.Skip(filter.Skip);
        if (filter.Take > 0) { spec.Take(filter.Take); }

        var recipes = await FindWithSpecification(spec);
        return RecipeEntityMapper.MapToRecipeModelsList(recipes.ToList());
    }

    public async Task<IEnumerable<Domain.Models.Recipes.Recipe>> FindRecipesWithSpecification(ISpecification<Recipe> spec)
    {
        var recipeEntities = await FindWithSpecification(spec);
        var recipeModels = RecipeEntityMapper.MapToRecipeModelsList(recipeEntities.ToList());
        return recipeModels;
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        await base.AddAsync(recipe);
        var dummyIdCounter = 0;
        foreach (var ingr in recipe.Ingredients)
        {
            _dbContext.Entry<Grocery>(ingr.Grocery).State = EntityState.Unchanged;
            _dbContext.Entry<GroceryCategory>(ingr.Grocery.Category).Entity.Id = ++dummyIdCounter;
            _dbContext.Entry<GroceryCategory>(ingr.Grocery.Category).State = EntityState.Unchanged;
        }
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        base.Update(recipe);
        var dummyIdCounter = 0;
        foreach (var ingr in recipe.Ingredients)
        {
            _dbContext.Entry<Grocery>(ingr.Grocery).State = EntityState.Unchanged;
            _dbContext.Entry<GroceryCategory>(ingr.Grocery.Category).Entity.Id = ++dummyIdCounter;
            _dbContext.Entry<GroceryCategory>(ingr.Grocery.Category).State = EntityState.Unchanged;
        }
    }

    public new async Task<bool> ExistsAsync(int id)
    {
        return await base.ExistsAsync(id);
    }
}
