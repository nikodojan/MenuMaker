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

    public double Calories { get; set; }

    public double GrammsFat { get; set; }

    public double GrammsCarbonhydrates { get; set; }

    public double GrammsSugar { get; set; }

    public double GrammsProtein { get; set; }

    public double GrammsFiber { get; set; }

    public static NutritionFacts operator+(NutritionFacts a, NutritionFacts b)
    {
        return new NutritionFacts()
        {
            Id = 0,
            GroceryId = 0,
            ServingSize = a.ServingSize,
            Calories = a.Calories + b.Calories,
            GrammsFat = a.GrammsFat + b.GrammsFat,
            GrammsCarbonhydrates = a.GrammsCarbonhydrates + b.GrammsCarbonhydrates,
            GrammsSugar = a.GrammsSugar + b.GrammsSugar,
            GrammsFiber = a.GrammsFiber + b.GrammsFiber,
            GrammsProtein = a.GrammsProtein + b.GrammsProtein
        };
    }

    public NutritionFacts CalculateForServingSize(double servingSizeAmount)
    {
        ServingSize = new UnitValue(ServingSize.Unit, servingSizeAmount);
        Calories = Calories / ServingSize.Amount * servingSizeAmount;
        GrammsFat = GrammsFat / ServingSize.Amount * servingSizeAmount;
        GrammsCarbonhydrates = GrammsCarbonhydrates / ServingSize.Amount * servingSizeAmount;
        GrammsFiber = GrammsFiber / ServingSize.Amount * servingSizeAmount;
        GrammsProtein = GrammsProtein / ServingSize.Amount * servingSizeAmount;
        GrammsSugar = GrammsSugar / ServingSize.Amount * servingSizeAmount;

        return this;
    }
}

