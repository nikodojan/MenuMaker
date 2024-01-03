using MenuMaker.Api.Models.ResponseModels;

namespace MenuMaker.Api.DTOs;

public class RecipeResponseModel
{
    public int Id { get; set; }

    public string Title { get; init; }

    public string? Description { get; init; }

    public string? ImgPath { get; init; }

    public Dictionary<string, List<string>> Instructions { get; set; } = new();

    public int? Portions { get; init; }

    public int? TimeInMinutes { get; init; }

    public NutritionFactsValuesResponseModel? NutritionFacts { get; set; } = null;

    public List<IngredientResponseModel> Ingredients { get; set; } = new();

}
