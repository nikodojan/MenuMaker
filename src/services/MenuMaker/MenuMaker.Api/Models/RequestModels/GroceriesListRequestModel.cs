using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.RequestModels;

public class GroceriesListRequestModel(int recipeId, short portions)
{
    [JsonPropertyName("recipeId")]
    public int RecipeId { get; } = recipeId;
    [JsonPropertyName("portions")]
    public short Portions { get; } = portions;
}
