using MenuMaker.Api.DTOs;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class RecipeMapper
{
    public static partial RecipeResponseModel MapToRecipeResponseModel(Recipe recipe);

    private static IngredientResponseModel MapToIngredientResponseModel(Ingredient ingredient) =>
        new IngredientMapper().ToIngredientResponseModel(ingredient);
}
