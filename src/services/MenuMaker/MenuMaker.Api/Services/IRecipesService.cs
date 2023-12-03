using MenuMaker.Api.DTOs;

namespace MenuMaker.Api.Services;
public interface IRecipesService
{
    Task<RecipeResponseModel> GetRecipeById(int id);
    Task<IEnumerable<RecipeResponseModel>> GetRecipes(bool includeIngredients, int skip, int take);
}