using MenuMaker.Domain.Common;

namespace MenuMaker.Domain.Models.Recipes;

public class GroceryCategory : Entity<int>
{
    public string Name { get; set; }
}


