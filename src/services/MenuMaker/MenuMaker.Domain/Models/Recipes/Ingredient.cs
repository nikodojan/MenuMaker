using MenuMaker.Domain.Models.Groceries;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Models.Recipes;

public class Ingredient
{
    public Guid Id { get; set; }

    public double? Amount { get; set; }

    public string? Unit { get; set; }

    public Grocery Grocery { get; set; } = new();

    [StringLength(50)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? PartOfDish { get; set; }
}

