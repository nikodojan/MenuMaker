using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public static partial class NutritionFactsMapper
{
    [MapProperty(new[] { nameof(NutritionFacts.ServingSize), nameof(NutritionFacts.ServingSize.Unit) },
        new[] { nameof(NutritionFactsValuesResponseModel.ReferenceAmountUnit) })]
    [MapProperty(new[] { nameof(NutritionFacts.ServingSize), nameof(NutritionFacts.ServingSize.Amount) },
        new[] { nameof(NutritionFactsValuesResponseModel.ReferenceAmount) })]
    public static partial NutritionFactsValuesResponseModel ToValuesReponseModel(NutritionFacts nutritionFacts);

    [MapProperty(new[] { nameof(NutritionFactsViewModel.ReferenceAmountUnit) },
        new[] { nameof(NutritionFacts.ServingSize), nameof(NutritionFacts.ServingSize.Unit) })]
    [MapProperty(new[] { nameof(NutritionFactsViewModel.ReferenceAmount) },
        new[] { nameof(NutritionFacts.ServingSize), nameof(NutritionFacts.ServingSize.Amount) })]
    //[MapProperty("ReferenceAmount",
    //    "ServingSize.Amount")]
    public static partial NutritionFacts MapToNutritionFacts(NutritionFactsViewModel nf);
}
