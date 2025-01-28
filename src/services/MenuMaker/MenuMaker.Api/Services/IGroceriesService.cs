using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;

namespace MenuMaker.Api.Services;
public interface IGroceriesService
{
    Task<Grocery> AddGrocery(Grocery grocery);
    Task DeleteGrocery(Guid groceryId);
    Task<IEnumerable<GroceryReponseModel>> GetAllGroceries();
    Task<GroceryReponseModel?> GetGroceryById(Guid id);
    Task<IEnumerable<GroceryCategory>> GetGroceryCategories();
    Task<Grocery> UpdateGrocery(Grocery grocery);
}