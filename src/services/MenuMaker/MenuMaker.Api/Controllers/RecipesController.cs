using MenuMaker.Api.Authentication;
using MenuMaker.Api.DTOs;
using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.RequestModels;
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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRecipeByIt([FromRoute] int id)
    {
        var recipe = await _recipesService.GetRecipeById(id);
        if (recipe == null) { return NotFound(); }
        return Ok(recipe);
    }

    [HttpPost]
    [ApiKey]
    public async Task<IActionResult> AddRecipe([FromBody] RecipeRequestModel recipe)
    {
        var newRecipe = await _recipesService.CreateRecipe(recipe.MapToRecipeModel());
        return Created(newRecipe.Id.ToString(), RecipeMapper.MapToRecipeResponseModel(newRecipe));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRecipe(int id, RecipeRequestModel recipe)
    {
        var updatedRecipe = await _recipesService.UpdateRecipe(recipe.MapToRecipeModel());
        return Ok(updatedRecipe);
    }
}
