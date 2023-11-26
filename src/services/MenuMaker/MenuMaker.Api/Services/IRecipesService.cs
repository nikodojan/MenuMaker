using MenuMaker.Api.DTOs;

namespace MenuMaker.Api.Services;
public interface IRecipesService
{
    Task<IEnumerable<RecipeResponseModel>> GetRecipes(bool includeIngredients, int skip, int take);
}