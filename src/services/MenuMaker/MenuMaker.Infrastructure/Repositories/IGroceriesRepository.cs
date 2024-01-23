using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Infrastructure.Entities.Recipes;
using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public interface IGroceriesRepository : IGenericRepository<Grocery, int>
{
    Task<IEnumerable<Domain.Models.Groceries.Grocery>> GetGroceries();
}
