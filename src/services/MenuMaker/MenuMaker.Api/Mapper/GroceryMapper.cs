using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public partial class GroceryMapper
{
    [MapProperty(new[] { nameof(Grocery.Category), nameof(Grocery.Category.Name) },
        new[] { nameof(GroceryReponseModel.Category) })]
    [MapProperty(nameof(Grocery.NameSelectable), nameof(GroceryReponseModel.Name))]
    public partial GroceryReponseModel ToGroceryReponseModel(Grocery grocery);
}
