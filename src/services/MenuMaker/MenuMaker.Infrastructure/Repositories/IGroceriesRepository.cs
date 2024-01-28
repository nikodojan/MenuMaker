using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public interface IGroceriesRepository : IGenericRepository<Grocery, int>
{
    Task AddGroceryAsync(Grocery grocery);
    Task<IEnumerable<Domain.Models.Groceries.Grocery>> GetGroceries();
    Task<Domain.Models.Groceries.Grocery?> GetGroceryById(int id);
    void Update(Grocery grocery);
}
