using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Infrastructure.Repositories;
public interface IRecipesRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipes();

    Task<IEnumerable<Recipe>> GetRecipesWithFilter(RecipeFilter filter);

    Task<Recipe> GetRecipe(int id);

    Task AddRecipeAsync(Entities.Recipes.Recipe recipe);

    Task<int> SaveChangesAsync();

    Task UpdateRecipeAsync(Entities.Recipes.Recipe recipe);

    Task<bool> ExistsAsync(int id);
}
