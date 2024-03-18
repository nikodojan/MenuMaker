using MenuMaker.Api.DTOs;
using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Api.Services;
public interface IRecipesService
{
    Task<Recipe> CreateRecipe(Recipe recipeModel);
    Task<RecipeResponseModel> GetRecipeById(int id);
    Task<IEnumerable<RecipeResponseModel>> GetRecipes(bool includeIngredients, int skip, int take);
    Task<Recipe?> UpdateRecipe(int id, Recipe recipeModel);
}