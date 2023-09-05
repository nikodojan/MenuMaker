using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MenuMaker.Domain.Aggregates.RecipeAggregate.ValueObjects;
using MenuMaker.Domain.Common;
using MenuMaker.Domain.Aggregates.RecipeAggregate.Constants;

namespace MenuMaker.Domain.Aggregates.RecipeAggregate;

public class NutritionFacts : Entity<int>
{
    public NutritionFacts()
    {

    }

    public int GroceryId { get; init; } //fk

    [RegularExpression($"[{RecipeConstants.Units.Gramms}|{RecipeConstants.Units.Milliliters}]")]

    public UnitValue ServingSize { get; set; } 
        = new UnitValue(RecipeConstants.Units.Gramms, 0);

    public UnitValue Calories { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);

    public UnitValue Fat { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);
    public UnitValue Carbonhydrates { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);
    public UnitValue Sugar { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);
    public UnitValue Protein { get; set; }
        = new UnitValue(RecipeConstants.Units.Gramms, 0);
}   

