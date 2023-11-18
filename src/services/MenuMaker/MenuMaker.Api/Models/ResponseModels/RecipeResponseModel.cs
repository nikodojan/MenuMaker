using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Api.DTOs;

public class RecipeResponseModel
{
    public string Title { get; init; }

    public string? Description { get; init; }

    public string? ImgPath { get; init; }

    public string Instructions { get; init; }

    public int? Portions { get; init; }

    public int? TimeInMinutes { get; init; }

    public int Calories { get; init; }

    public IEnumerable<IngredientResponseModel> Ingredients { get; set; } = new List<IngredientResponseModel>();
}
