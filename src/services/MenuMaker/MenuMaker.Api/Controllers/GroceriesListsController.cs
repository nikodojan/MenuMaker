using MenuMaker.Api.Services;
using MenuMaker.Api.Validations.CustomValidators;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


    public async Task<IActionResult> Get([FromQuery] string recipeIds)
    {
        var validator = new RecipeListParameterValidator();
        var validationResult = await validator.Validate(recipeIds);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Message);
        }

        var groecriesList = await _groceriesListService.GetGroceryList(validationResult.RecipeIds);

        return Ok(groecriesList);
    }
}
