using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.Models.RequestModels;

public class IngredientRequestModel
{
    public int Id { get; set; }

    public double? Amount { get; set; }

    public string? Unit { get; set; }

    public int GroceryId { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? PartOfDish { get; set; }
}
