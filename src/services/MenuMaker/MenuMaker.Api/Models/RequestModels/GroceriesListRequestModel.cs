using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.RequestModels;

public class GroceriesListRequestModel(Guid recipeId, short portions)
{
    [JsonPropertyName("recipeId")]
    public Guid RecipeId { get; } = recipeId;
    [JsonPropertyName("portions")]
    public short Portions { get; } = portions;
}
