using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.ResponseModels;

public class GroceryReponseModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;
    [JsonPropertyName("nutritionFacts")]
    public NutritionFactsValuesResponseModel? NutritionFacts { get; set; }
}
