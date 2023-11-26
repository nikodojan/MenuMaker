using Riok.Mapperly.Abstractions;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class IngredientEntityMapper
{
    public static partial Domain.Models.Recipes.Ingredient MapToIngredientModel(Entities.Recipes.Ingredient entity);

    public static partial List<Domain.Models.Recipes.Ingredient> MapToIngredientModelsList(List<Entities.Recipes.Ingredient> entities);
}
