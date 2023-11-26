using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Entities.Recipes;
using MenuMaker.Infrastructure.Persistence;
using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public class GroceryRepository : GenericRepository<Grocery, int, RecipesContext>,IGroceriesRepositorys
{
    public GroceryRepository(RecipesContext dbContext) : base(dbContext)
    {
    }

    public Task AddGroceries(IEnumerable<Domain.Models.Recipes.Grocery> groceries)
    {
        throw new NotImplementedException();
    }

    public Task AddGrocery(Domain.Models.Recipes.Grocery grocery)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Models.Recipes.Grocery>> GetGroceries()
    {
        throw new NotImplementedException();
    }
}
