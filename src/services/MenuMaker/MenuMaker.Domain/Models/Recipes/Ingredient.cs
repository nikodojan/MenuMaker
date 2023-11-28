using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Models.Recipes;

public class Ingredient
{
    public int Id { get; set; }

    public double? Amount { get; set; }

    public string? Unit { get; set; }

    /// <summary>
    /// Grocery name.
    /// </summary>
    //[StringLength(50)]
    //public string Name { get; set; } = string.Empty;

    public Grocery Grocery { get; set; } = default!;

    [StringLength(50)]
    public string? Description { get; set; }

    /// <summary>
    /// Property to separate different components of a dish (e.g. Salad, Dressing, Topping)
    /// </summary>
    [StringLength(50)]
    public string? PartOfDish { get; set; }

    public int RecipeId { get; set; } // FK, one Recipe has many Ingredients
}

