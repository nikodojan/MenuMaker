using MenuMaker.Api.Models.ResponseModels;

namespace MenuMaker.Api.Services;
public interface IGroceriesService
{
    Task<IEnumerable<GroceryReponseModel>> GetAllGroceries();
    Task<GroceryReponseModel> GetGroceryById(int id);
}