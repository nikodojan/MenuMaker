using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Mappers;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Infrastructure.Repositories;
public class RecipesRepository : GenericRepository<Infrastructure.Entities.Recipes.Recipe, int, RecipesContext>, IRecipesRepository
{
    public RecipesRepository(RecipesContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Recipe>> GetAllRecipes()
    {
        var recipes = await GetAllAsync();
        return RecipeEntityMapper.MapToRecipeModelsList(recipes.ToList());
    }

    public Task<Recipe> GetRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Recipe>> GetRecipesWithFilter(RecipeFilter filter)
    {
        var spec = new BaseSpecification<Entities.Recipes.Recipe>();
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
}
