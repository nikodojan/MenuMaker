using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.RequestModels;

public class GroceriesListRequestModel
{
    [JsonPropertyName("recipeId")]
    public int RecipeId { get; set; }
    [JsonPropertyName("portions")]
    public short Portions { get; set; }
}
