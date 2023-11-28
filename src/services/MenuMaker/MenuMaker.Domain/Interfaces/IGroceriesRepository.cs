using MenuMaker.Domain.Models.Groceries;

namespace MenuMaker.Domain.Interfaces;
public interface IGroceriesRepository
{
    Task<IEnumerable<Grocery>> GetGroceries();

    Task AddGrocery(Grocery grocery);

    Task AddGroceries(IEnumerable<Grocery> groceries);
}
