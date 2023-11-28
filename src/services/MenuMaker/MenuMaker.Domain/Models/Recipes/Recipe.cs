using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Models.Recipes;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }

    [StringLength(300)]
    public string? ImgPath { get; set; }

    [Required]
    [StringLength(2000)]
    public string Instructions { get; set; }

    public int? Portions { get; set; }

    public int? TimeInMinutes { get; set; }

    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

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
