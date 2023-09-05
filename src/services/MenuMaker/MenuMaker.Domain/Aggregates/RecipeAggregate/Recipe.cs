using MenuMaker.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Aggregates.RecipeAggregate;

public class Recipe : Entity<int>
{
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
}
