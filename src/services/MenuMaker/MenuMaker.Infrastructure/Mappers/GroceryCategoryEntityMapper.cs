using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Infrastructure.Entities.Recipes;
using Riok.Mapperly.Abstractions;
using GroceryCategory = MenuMaker.Infrastructure.Entities.Recipes.GroceryCategory;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class GroceryCategoryEntityMapper
{
    public static partial Domain.Models.Groceries.GroceryCategory MapToGroceryCategoryModel(this GroceryCategory entity);

    public static partial GroceryCategory MapToGroceryCategoryEntity(this Domain.Models.Groceries.GroceryCategory model);

    public static partial List<Domain.Models.Groceries.GroceryCategory> MapToGroceryCategoryModels(this IEnumerable<GroceryCategory> entities);

    public static partial List<GroceryCategory> MapToGroceryCategoryEntities(this IEnumerable<Domain.Models.Groceries.GroceryCategory> models);
}
