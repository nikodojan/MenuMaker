using MenuMaker.Domain.Models.Groceries;

namespace MenuMaker.Domain.Interfaces;
public interface IGroceriesRepository2
{
    Task<IEnumerable<Grocery>> GetGroceries();
}
