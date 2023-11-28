using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Services;
using MenuMaker.Api.Validations.CustomValidators;
using Microsoft.AspNetCore.Mvc;

namespace MenuMaker.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class GroceriesListsController : ControllerBase
{
    private readonly IGroceriesListService _groceriesListService;

    public GroceriesListsController(IGroceriesListService groceriesListService)
    {
        _groceriesListService = groceriesListService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string recipeIds)
    {
        var validator = new RecipeListParameterValidator();
        var validationResult = await validator.Validate(recipeIds);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Message);
        }

        var groceriesList = await _groceriesListService.GetGroceryList(validationResult.RecipeIds);

        return Ok(groceriesList);
    }

    [HttpPost]
    public async Task<IActionResult> GenerateGroceriesList([FromBody] GroceriesListRequestModel[] recipesAndPortions)
    {
        var groceriesList = await _groceriesListService.GetGroceryList(recipesAndPortions);
        return Ok(groceriesList);
    }
}
