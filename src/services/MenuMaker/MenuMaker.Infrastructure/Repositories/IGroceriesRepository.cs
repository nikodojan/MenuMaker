using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public interface IGroceriesRepository : IGenericRepository<Grocery, Guid>
{
    Task AddGroceryAsync(Grocery grocery);
    Task<IEnumerable<Domain.Models.Groceries.Grocery>> GetGroceries();
    Task<Domain.Models.Groceries.Grocery?> GetGroceryById(Guid id);
    void Update(Grocery grocery);
    void ClearTracker();
}
