using Riok.Mapperly.Abstractions;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class RecipeEntityMapper
{
    public static partial Domain.Models.Recipes.Recipe MapToRecipeModel(Entities.Recipes.Recipe entity);

    public static partial List<Domain.Models.Recipes.Recipe> MapToRecipeModelsList(List<Entities.Recipes.Recipe> entities);
}
