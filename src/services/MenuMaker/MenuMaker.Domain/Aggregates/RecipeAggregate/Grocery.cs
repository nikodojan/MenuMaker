using MenuMaker.Domain.Common;

namespace MenuMaker.Domain.Aggregates.RecipeAggregate;

public class Grocery : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public GroceryCategory Category { get; set; }

    public string? StandardUnit { get; set; }

    public virtual NutritionFacts? NutritionFacts { get; set; }
}

