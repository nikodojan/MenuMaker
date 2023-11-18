using MenuMaker.Domain.Common;

namespace MenuMaker.Domain.Models.Recipes;

public class Grocery : Entity<int>
{
    public string NameSelectable { get; set; } = string.Empty;

    public string? NameSingular { get; set; }

    public string? NamePlural { get; set; }

    public GroceryCategory Category { get; set; }

    public string StandardUnit { get; set; }

    public virtual NutritionFacts? NutritionFacts { get; set; }
}

