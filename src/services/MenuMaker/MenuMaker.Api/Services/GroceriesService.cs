using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Api.Services;

public class GroceriesService : IGroceriesService
{
    private readonly IGroceriesRepository _groceriesRepository;

    public GroceriesService(IGroceriesRepository groceriesRepository)
    {
        _groceriesRepository = groceriesRepository;
    }

    public async Task<IEnumerable<GroceryReponseModel>> GetAllGroceries()
    {
        var groceryModels = await _groceriesRepository.GetGroceries();
        return GroceryMapper.MapToGroceryReponseModelsList(groceryModels.ToList());
    }

    public async Task<GroceryReponseModel> GetGroceryById(int id)
    {
        throw new NotImplementedException();
    }
}
