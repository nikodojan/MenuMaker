using MenuMaker.Api.DTOs;
using MenuMaker.Api.Services;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var spec = new BaseSpecification<Recipe>();
        if (includeIngredients)
        {
            spec.AddInclude(q =>
                q.Include(r => r.Ingredients)
                    .ThenInclude(i => i.Grocery)
                    .ThenInclude(g => g.Category)
                );
        }
        spec.Skip(skip);
        if (take > 0) { spec.Take(take); }

        return Ok(await _recipesService.GetRecipes(spec));
    }
}
