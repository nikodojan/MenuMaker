using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class GroceryMapper
{
    [MapProperty(
        new[] { nameof(Grocery.Category), nameof(Grocery.Category.Name) },
        new[] { nameof(GroceryReponseModel.Category) })]
    [MapProperty(
        nameof(Grocery.NameSelectable),
        nameof(GroceryReponseModel.Name))]
    public static partial GroceryReponseModel MapToGroceryReponseModel(Grocery grocery);

    [MapProperty(
        new[] { nameof(Grocery.Category), nameof(Grocery.Category.Name) },
        new[] { nameof(GroceryReponseModel.Category) })]
    [MapProperty(
        nameof(Grocery.NameSelectable),
        nameof(GroceryReponseModel.Name))]
    public static partial List<GroceryReponseModel> MapToGroceryReponseModelsList(List<Grocery> groceryModels);

    [MapProperty(
        new[] { nameof(GroceryRequestModel.CategoryId) },
        new[] { nameof(Grocery.Category), nameof(Grocery.Category.Id) })]
    public static partial Grocery MapToGroceryModel(GroceryRequestModel groceryRequestModel);

    private static NutritionFacts MapToNutritionFacts(NutritionFactsViewModel nf) =>
        NutritionFactsMapper.MapToNutritionFacts(nf);

    private static NutritionFactsValuesResponseModel MapToNutritionFactsValuesResponseModel(NutritionFacts model) =>
        NutritionFactsMapper.ToValuesReponseModel(model);
}
