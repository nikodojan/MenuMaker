using MenuMaker.Domain.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.ResponseModels;

public class NutritionFactsValuesResponseModel
{
    [JsonPropertyName("referenceAmount")]
    public int ReferenceAmount { get; set; } = 100;

    [JsonPropertyName("referenceAmountUnit")]
    public string ReferenceAmountUnit { get; set; } = "g";

    [JsonPropertyName("calories")]
    public double Calories { get; set; }

    [JsonPropertyName("fat")]
    public double GrammsFat { get; set; }

    [JsonPropertyName("carbonhydrates")]
    public double GrammsCarbonhydrates { get; set; }

    [JsonPropertyName("sugar")]
    public double GrammsSugar { get; set; }

    [JsonPropertyName("protein")]
    public double GrammsProtein { get; set; }

    [JsonPropertyName("fiber")]
    public double GrammsFiber { get; set; }
}
