using MenuMaker.Domain.Models.Groceries;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class GroceryEntityMapper
{
    public static partial Grocery MapToGroceryModel(Entities.Recipes.Grocery entity);

    public static partial List<Grocery> MapToGroceryModelsList(List<Entities.Recipes.Grocery> entities);

    public static partial Entities.Recipes.Grocery MapToGroceryEntity(Grocery entity);

    public static partial List<Entities.Recipes.Grocery> MapToGroceryEntityList(List<Grocery> entity);
}
