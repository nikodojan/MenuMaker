using MenuMaker.Domain.Common;

namespace MenuMaker.Domain.Aggregates.RecipeAggregate;

public class GroceryCategory : Entity<int>
{
    public string Name { get; set; }
}


