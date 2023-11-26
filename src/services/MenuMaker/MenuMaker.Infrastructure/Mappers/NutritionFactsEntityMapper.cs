using Riok.Mapperly.Abstractions;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class NutritionFactsEntityMapper
{
    public static partial Domain.Models.Recipes.NutritionFacts MapToNutritionFactsModel(Entities.Recipes.NutritionFacts entity);

    public static partial List<Domain.Models.Recipes.NutritionFacts> MapToNutritionFactsModelsList(List<Entities.Recipes.NutritionFacts> entities);
}
