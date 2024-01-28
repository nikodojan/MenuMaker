using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;

namespace MenuMaker.Api.Services;
public interface IGroceriesService
{
    Task AddGrocery(Grocery grocery);
    Task DeleteGrocery(int groceryId);
    Task<IEnumerable<GroceryReponseModel>> GetAllGroceries();
    Task UpdateGrocery(Grocery grocery);
}