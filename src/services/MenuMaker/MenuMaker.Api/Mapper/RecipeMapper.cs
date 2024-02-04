using MenuMaker.Api.DTOs;
using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;
using System.Security;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class RecipeMapper
{
    public static partial RecipeResponseModel MapToRecipeResponseModel(Recipe recipe);

    private static IngredientResponseModel MapToIngredientResponseModel(Ingredient ingredient) =>
        IngredientMapper.ToIngredientResponseModel(ingredient);

    public static partial Recipe MapToRecipeModel(RecipeRequestModel recipeRequest);

    private static Ingredient MapToIngredientRequestModel(IngredientRequestModel ingredientRequest) => 
        IngredientMapper.MapToIngredientModel(ingredientRequest);
}
