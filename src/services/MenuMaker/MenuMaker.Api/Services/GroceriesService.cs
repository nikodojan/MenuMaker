using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Mappers;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;

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

    //public async Task<GroceryReponseModel> GetGroceryById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task AddGrocery(Domain.Models.Groceries.Grocery grocery)
    {
        var groceryEntity = GroceryEntityMapper.MapToGroceryEntity(grocery);
        await _groceriesRepository.AddGroceryAsync(groceryEntity);
        await _groceriesRepository.SaveChangesAsync();
        
    }

    public async Task UpdateGrocery(Domain.Models.Groceries.Grocery grocery)
    {
        var groceryEntity = GroceryEntityMapper.MapToGroceryEntity(grocery);
        _groceriesRepository.Update(groceryEntity);
        await _groceriesRepository.SaveChangesAsync();
    }
}
