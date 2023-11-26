using Riok.Mapperly.Abstractions;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class GroceryEntityMapper
{
    public static partial Domain.Models.Recipes.Grocery MapToGroceryModel(Entities.Recipes.Grocery entity);

    public static partial List<Domain.Models.Recipes.Grocery> MapToGroceryModelsList(List<Entities.Recipes.Grocery> entities);

    public static partial Entities.Recipes.Grocery MapToGroceryEntity(Domain.Models.Recipes.Grocery entity);

    public static partial List<Entities.Recipes.Grocery> MapToGroceryEntity(List<Domain.Models.Recipes.Grocery> entity);
}
