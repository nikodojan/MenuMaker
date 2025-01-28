namespace MenuMaker.Api.Models.RequestModels;

public class GroceryRequestModel
{

    public Guid? Id { get; set; } 
    public string NameSelectable { get; set; } = string.Empty;

    public string? NameSingular { get; set; }

    public string? NamePlural { get; set; }

    public required string StandardUnit { get; set; }

    public Guid CategoryId { get; set; }

    public required NutritionFactsViewModel NutritionFacts { get; set; }

    public bool HasNutritionValues { get; set; }
}
