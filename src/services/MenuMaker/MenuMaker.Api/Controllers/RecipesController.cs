using MenuMaker.Api.DTOs;
using MenuMaker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MenuMaker.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipesService _recipesService;

    public RecipesController(IRecipesService recipesService)
    {
        _recipesService = recipesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeResponseModel>>> GetRecipes(
        [FromQuery] bool includeIngredients,
        [FromQuery] int skip,
        [FromQuery] int take)
    {
        var recipes = await _recipesService.GetRecipes(includeIngredients, skip, take);

        return Ok(recipes);
    }
}
