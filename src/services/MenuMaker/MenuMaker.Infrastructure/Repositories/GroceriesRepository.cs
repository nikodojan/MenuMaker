using MenuMaker.Domain.Interfaces;
using MenuMaker.Infrastructure.Entities.Recipes;
using MenuMaker.Infrastructure.Mappers;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Repositories;
public class GroceriesRepository : GenericRepository<Grocery, Guid, RecipesContext>, IGroceriesRepository
{
    public GroceriesRepository(RecipesContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Domain.Models.Groceries.Grocery>> GetGroceries()
    {
        var spec = new BaseSpecification<Grocery>();
        spec.AddInclude(q => q.Include(g => g.Category));
        var groceries = await FindWithSpecification(spec);
        return GroceryEntityMapper.MapToGroceryModelsList(groceries.ToList());
    }

    public async Task<Domain.Models.Groceries.Grocery?> GetGroceryById(Guid id)
    {
        var grocery = await GetAsync(id, gr => gr.Category);
        if (grocery is null) 
            return null;
        return GroceryEntityMapper.MapToGroceryModel(grocery);
    }

    public async Task AddGroceryAsync(Grocery grocery)
    {
        await base.AddAsync(grocery);
        _dbContext.Entry(grocery.Category).State = EntityState.Unchanged;
    }

    public new void Update(Grocery grocery)
    {
        base.Update(grocery);
        _dbContext.Entry(grocery.Category).State = EntityState.Unchanged;
    }
}
