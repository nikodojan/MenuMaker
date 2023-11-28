using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public partial class IngredientMapper
{
    public partial IngredientResponseModel ToIngredientResponseModel(Ingredient ingredient);

    private GroceryReponseModel MapToGroceryReponseModel(Grocery grocery) => GroceryMapper.MapToGroceryReponseModel(grocery);
}
