using MenuMaker.Domain.Models.Recipes;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.Models.ResponseModels;

public class IngredientResponseModel
{
    public Guid Id { get; set; }
    public double? Amount { get; set; }
    public string? Unit { get; set; }
    public required GroceryReponseModel Grocery { get; set; }
    public string? Description { get; set; }
    public string? PartOfDish { get; set; }
}
