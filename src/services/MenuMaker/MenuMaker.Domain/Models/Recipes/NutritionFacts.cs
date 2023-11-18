using MenuMaker.Domain.Common;
using MenuMaker.Domain.Models.Recipes.ValueObjects;

namespace MenuMaker.Domain.Models.Recipes;

public class NutritionFacts : Entity<int>
{
    public NutritionFacts()
    {

    }

    public int GroceryId { get; init; }

    public UnitValue ServingSize { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);

    public int Calories { get; set; }

    public int GrammsFat { get; set; }

    public int GrammsCarbonhydrates { get; set; }

    public int GrammsSugar { get; set; }

    public int GrammsProtein { get; set; }
}

