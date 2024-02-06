using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Infrastructure.Mappers;
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

    public async Task<GroceryReponseModel?> GetGroceryById(int id)
    {
        if ((await _groceriesRepository.GetGroceryById(id)) is Grocery grocery)
            return GroceryMapper.MapToGroceryReponseModel(grocery);
        else
            return null;

    }

    public async Task<Grocery> AddGrocery(Domain.Models.Groceries.Grocery grocery)
    {
        var groceryEntity = GroceryEntityMapper.MapToGroceryEntity(grocery);
        await _groceriesRepository.AddGroceryAsync(groceryEntity);
        await _groceriesRepository.SaveChangesAsync();
        _groceriesRepository.ClearTracker();
        groceryEntity = await _groceriesRepository.GetAsync(groceryEntity.Id, gr => gr.Category);
        return GroceryEntityMapper.MapToGroceryModel(groceryEntity!);
    }

    public async Task<Grocery> UpdateGrocery(Domain.Models.Groceries.Grocery grocery)
    {
        var groceryEntity = GroceryEntityMapper.MapToGroceryEntity(grocery);
        _groceriesRepository.Update(groceryEntity);
        await _groceriesRepository.SaveChangesAsync();
        _groceriesRepository.ClearTracker();
        groceryEntity = await _groceriesRepository.GetAsync(groceryEntity.Id, gr=>gr.Category);
        return GroceryEntityMapper.MapToGroceryModel(groceryEntity!);
    }

    public async Task DeleteGrocery(int groceryId)
    {
        await _groceriesRepository.DeleteAsync(groceryId);
        await _groceriesRepository.SaveChangesAsync();
    }
}
