using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Domain.Interfaces;
public interface IGroceriesRepositorys
{
    Task<IEnumerable<Grocery>> GetGroceries();

    Task AddGrocery(Grocery grocery);

    Task AddGroceries(IEnumerable<Grocery> groceries);
}
