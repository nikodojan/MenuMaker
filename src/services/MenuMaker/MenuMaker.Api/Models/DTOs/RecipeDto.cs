using MenuMaker.Domain.Aggregates.RecipeAggregate;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.DTOs;

public class RecipeDto
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public string? ImgPath { get; set; }

    public string Instructions { get; set; }

    public int? Portions { get; set; }

    public int? Minutes { get; }

    public int? TimeInMinutes { get; set; }

    public int Calories { get; set; }

    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
