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
}
