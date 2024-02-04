using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class IngredientMapper
{
    public static partial IngredientResponseModel ToIngredientResponseModel(Ingredient ingredient);

    [MapProperty(
        new[] { nameof(IngredientRequestModel.GroceryId) }, 
        new[] {nameof(Ingredient.Grocery), nameof(Ingredient.Grocery.Id)})]
    public static partial Ingredient MapToIngredientModel(IngredientRequestModel ingredientRequest);

    private static GroceryReponseModel MapToGroceryReponseModel(Grocery grocery) => GroceryMapper.MapToGroceryReponseModel(grocery);

    private static Grocery MapToGrocery(GroceryRequestModel groceryRequest) => GroceryMapper.MapToGroceryModel(groceryRequest);
}
