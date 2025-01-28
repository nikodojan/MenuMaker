using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.Models.RequestModels;

public class IngredientRequestModel
{
    public Guid Id { get; set; }

    public double? Amount { get; set; }

    public string? Unit { get; set; }

    public Guid GroceryId { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [StringLength(50)]
    public string? PartOfDish { get; set; }
}
