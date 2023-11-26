using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Domain.Interfaces;
public interface IRecipesRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipes();

    Task<IEnumerable<Recipe>> GetRecipesWithFilter(RecipeFilter filter);

    Task<Recipe> GetRecipe(int id);

}
