using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.Models.RequestModels;

public class RecipeRequestModel
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public string? ImgPath { get; set; }

    public Dictionary<string, List<string>> Instructions { get; set; } = new();

    public int Portions { get; set; }

    public int? TimeInMinutes { get; set; }

    public virtual List<IngredientRequestModel> Ingredients { get; set; } = new();
}
