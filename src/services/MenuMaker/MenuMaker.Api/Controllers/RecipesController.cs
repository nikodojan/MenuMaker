using MenuMaker.Api.DTOs;
using MenuMaker.Api.Services;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
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

    // GET: api/<RecipesController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes(
        [FromQuery] bool includeIngredients,
        [FromQuery] int skip,
        [FromQuery] int take)
    {
        var spec = new BaseSpecification<Recipe>();
        if (includeIngredients)
        {
            spec.AddInclude(q => q.Include(r=>r.Ingredients).ThenInclude(i=>i.Grocery));
        }

        spec.Skip(skip);
        
        if (take > 0) { spec.Take(take); }

        return Ok(await _recipesService.GetRecipes(spec));
    }

    // GET api/<RecipesController>/5
    [HttpGet("{id}")]
    public async Task<double> Get(int id)
    {
        return await _recipesService.GetCalories(id);
    }

    // POST api/<RecipesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<RecipesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<RecipesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
