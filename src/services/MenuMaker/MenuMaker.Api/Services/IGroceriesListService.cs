using MenuMaker.Api.Models.ResponseModels;

namespace MenuMaker.Api.Services;
public interface IGroceriesListService
{
    Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<(int, int)> recipeIds);
}