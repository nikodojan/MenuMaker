using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public partial class IngredientMapper
{
    
    private readonly GroceryMapper _groceryMapper = new GroceryMapper();

    public partial IngredientResponseModel ToIngredientResponseModel(Ingredient ingredient);

    private GroceryReponseModel MapToGroceryReponseModel(Grocery grocery) => new GroceryMapper().ToGroceryReponseModel(grocery);
}
