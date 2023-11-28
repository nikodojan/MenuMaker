using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;

namespace MenuMaker.Api.Services;
public interface IGroceriesListService
{
    Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<(int, short)> recipeIds);
    Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<GroceriesListRequestModel> listRequests);
}