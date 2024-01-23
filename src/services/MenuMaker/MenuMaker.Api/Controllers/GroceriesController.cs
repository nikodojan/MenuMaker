using MenuMaker.Api.Authentication;
using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MenuMaker.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class GroceriesController : ControllerBase
{
    private readonly IGroceriesService _groceriesService;

    public GroceriesController(IGroceriesService groceriesService)
    {
        _groceriesService = groceriesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _groceriesService.GetAllGroceries());
    }

    [HttpPost]
    //[ApiKey]
    public async Task<IActionResult> AddGrocery([FromBody] GroceryRequestModel grocery)
    {
        var groceryModel = GroceryMapper.MapToGroceryModel(grocery);
        await _groceriesService.AddGrocery(groceryModel);
        return Created();
    } 

}
