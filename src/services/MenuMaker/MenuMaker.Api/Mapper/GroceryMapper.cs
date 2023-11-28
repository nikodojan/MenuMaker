using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class GroceryMapper
{
    [MapProperty(new[] { nameof(Grocery.Category), nameof(Grocery.Category.Name) },
        new[] { nameof(GroceryReponseModel.Category) })]
    [MapProperty(nameof(Grocery.NameSelectable), nameof(GroceryReponseModel.Name))]
    public static partial GroceryReponseModel MapToGroceryReponseModel(Grocery grocery);

    [MapProperty(new[] { nameof(Grocery.Category), nameof(Grocery.Category.Name) },
    new[] { nameof(GroceryReponseModel.Category) })]
    [MapProperty(nameof(Grocery.NameSelectable), nameof(GroceryReponseModel.Name))]
    public static partial List<GroceryReponseModel> MapToGroceryReponseModelsList(List<Grocery> groceryModels);
}
