namespace MenuMaker.Infrastructure.Entities.Recipes;

public class Grocery : Entity<Guid>
{
    public string NameSelectable { get; set; } = string.Empty;

    public string? NameSingular { get; set; }

    public string? NamePlural { get; set; }

    public GroceryCategory Category { get; set; }

    public Guid CategoryId { get; set; }

    public string StandardUnit { get; set; }

    public virtual NutritionFacts NutritionFacts { get; set; }

    public bool HasNutritionValues { get; set; }
}

