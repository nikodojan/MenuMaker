using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Models.Recipes;

public class Recipe
{
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    public string? ImgPath { get; set; }

    public Dictionary<string, List<string>> Instructions { get; set; } = new();

    public int Portions { get; set; }

    public int? TimeInMinutes { get; set; }

    public virtual List<Ingredient> Ingredients { get; set; } = new();

    public override string ToString()
    {
        return $"Recipe for {Title}";
    }

    public List<Ingredient> CalculateIngredientsByPortions(int portions)
    {
        if (portions == Portions) 
            return Ingredients;

        var ingredients = new List<Ingredient>();

        foreach (var ingr in Ingredients)
        {
            ingr.Amount = ingr.Amount / Portions * portions;
            ingredients.Add(ingr);
        }

        return ingredients;
    }
}
