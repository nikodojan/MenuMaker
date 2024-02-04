namespace MenuMaker.Infrastructure.Entities.Recipes;

public class Recipe : Entity<int>
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public string? ImgPath { get; set; }

    public int Portions { get; set; }

    public int? TimeInMinutes { get; set; }

    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public Dictionary<string, List<string>> Instructions { get; set; } = new();

}
