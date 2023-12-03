using MenuMaker.Api.Models.ResponseModels;

namespace MenuMaker.Api.DTOs;

public class RecipeResponseModel
{
    public int Id { get; set; }

    public string Title { get; init; }

    public string? Description { get; init; }

    public string? ImgPath { get; init; }

    public string Instructions { get; init; }

    public int? Portions { get; init; }

    public int? TimeInMinutes { get; init; }

    public NutritionFactsValuesResponseModel? NutritionFacts { get; set; } = null;

    public IEnumerable<IngredientResponseModel> Ingredients { get; set; } = new List<IngredientResponseModel>();
}
