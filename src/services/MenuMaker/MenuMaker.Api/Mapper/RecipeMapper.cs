using MenuMaker.Api.DTOs;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public partial class RecipeMapper
{
    public partial RecipeResponseModel ToRecipeResponseModel(Recipe recipe);

    private IngredientResponseModel MapToIngredientResponseModel(Ingredient ingredient) =>
        new IngredientMapper().ToIngredientResponseModel(ingredient);
}
