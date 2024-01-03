using Riok.Mapperly.Abstractions;
using Recipe = MenuMaker.Infrastructure.Entities.Recipes.Recipe;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class RecipeEntityMapper
{
    public static partial Domain.Models.Recipes.Recipe MapToRecipeModel(Recipe entity);

    public static partial List<Domain.Models.Recipes.Recipe> MapToRecipeModelsList(List<Recipe> entities);
}
