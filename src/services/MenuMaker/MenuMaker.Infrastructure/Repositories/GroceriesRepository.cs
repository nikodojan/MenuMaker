using MenuMaker.Domain.Interfaces;
using MenuMaker.Infrastructure.Entities.Recipes;
using MenuMaker.Infrastructure.Mappers;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public class GroceriesRepository : GenericRepository<Grocery, int, RecipesContext>, IGroceriesRepository
{
    public GroceriesRepository(RecipesContext dbContext) : base(dbContext)
    {
    }

    public Task AddGroceries(IEnumerable<Domain.Models.Groceries.Grocery> groceries)
    {
        throw new NotImplementedException();
    }

    public Task AddGrocery(Domain.Models.Groceries.Grocery grocery)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Domain.Models.Groceries.Grocery>> GetGroceries()
    {
        var spec = new BaseSpecification<Grocery>();
        spec.AddInclude(q => q.Include(g => g.Category));
        var groceries = await FindWithSpecification(spec);
        return GroceryEntityMapper.MapToGroceryModelsList(groceries.ToList());
    }

    public async Task<Domain.Models.Groceries.Grocery> GetGroceryById(int id)
    {
        var grocery = await GetAsync(id);
        if (grocery is null) return null;
        return GroceryEntityMapper.MapToGroceryModel(grocery);
    }
}
