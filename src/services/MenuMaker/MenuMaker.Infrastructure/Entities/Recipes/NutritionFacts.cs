using MenuMaker.Domain.Constants;
using MenuMaker.Domain.Models.ValueObjects;

namespace MenuMaker.Infrastructure.Entities.Recipes;

public class NutritionFacts
{
    public NutritionFacts()
    {

    }

    public UnitValue ServingSize { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);

    public double Calories { get; set; }

    public double GrammsFat { get; set; }

    public double GrammsCarbonhydrates { get; set; }

    public double GrammsSugar { get; set; }

    public double GrammsProtein { get; set; }

    public double GrammsFiber { get; set; }
}

