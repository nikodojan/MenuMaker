using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.RequestModels;

public class NutritionFactsViewModel
{
    [JsonPropertyName("referenceAmount")]
    public int ReferenceAmount { get; set; } = 100;

    [JsonPropertyName("referenceAmountUnit")]
    public string ReferenceAmountUnit { get; set; } = "g";

    [JsonPropertyName("calories")]
    public int Calories { get; set; }

    [JsonPropertyName("fat")]
    public int GrammsFat { get; set; }

    [JsonPropertyName("carbonhydrates")]
    public int GrammsCarbonhydrates { get; set; }

    [JsonPropertyName("sugar")]
    public int GrammsSugar { get; set; }

    [JsonPropertyName("protein")]
    public int GrammsProtein { get; set; }

    [JsonPropertyName("fiber")]
    public int GrammsFiber { get; set; }
}
