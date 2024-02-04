using MenuMaker.Domain.Models.Recipes;

namespace MenuMaker.Domain.Models.Groceries;

public class Grocery
{
    public int Id { get; set; }

    public string NameSelectable { get; set; } = string.Empty;

    public string? NameSingular { get; set; }

    public string? NamePlural { get; set; }

    public GroceryCategory Category { get; set; } = new();

    public string StandardUnit { get; set; } = Constants.RecipeConstants.Units.Gramms;

    public NutritionFacts NutritionFacts { get; set; } = new();

    public bool HasNutritionValues { get; set; }
}

