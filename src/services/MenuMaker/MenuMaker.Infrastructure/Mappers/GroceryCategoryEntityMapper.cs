using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Infrastructure.Entities.Recipes;
using Riok.Mapperly.Abstractions;
using GroceryCategory = MenuMaker.Infrastructure.Entities.Recipes.GroceryCategory;

namespace MenuMaker.Infrastructure.Mappers;
[Mapper]
public static partial class GroceryCategoryEntityMapper
{
    public static partial Domain.Models.Groceries.GroceryCategory MapToGroceryCategoryModel(GroceryCategory entity);

    public static partial GroceryCategory MapToGroceryCategoryEntity(Domain.Models.Groceries.GroceryCategory model);
}
