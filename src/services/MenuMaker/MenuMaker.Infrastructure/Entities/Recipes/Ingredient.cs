
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Infrastructure.Entities.Recipes;

public class Ingredient : Entity<Guid>
{
    public double? Amount { get; set; }

    public string? Unit { get; set; }

    public Guid GroceryId { get; set; }

    public Grocery Grocery { get; set; } = default!;

    [StringLength(50)]
    public string? Description { get; set; }

    /// <summary>
    /// Property to separate different components of a dish (e.g. Salad, Dressing, Topping)
    /// </summary>
    [StringLength(50)]
    public string? PartOfDish { get; set; }

    public Guid RecipeId { get; set; }
}

