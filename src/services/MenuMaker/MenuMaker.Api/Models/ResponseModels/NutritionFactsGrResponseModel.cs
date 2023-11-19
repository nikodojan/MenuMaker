using System.Text.Json.Serialization;

namespace MenuMaker.Api.Models.ResponseModels;

public class NutritionFactsGrResponseModel
{
    public class NutritionValues
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
    }

    public int Id { get; set; }

    public NutritionValues Values { get; set; }

    public GroceryReponseModel Grocery { get; set; } = new GroceryReponseModel();
}
