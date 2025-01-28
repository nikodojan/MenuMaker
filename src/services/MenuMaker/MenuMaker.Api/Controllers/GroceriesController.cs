using MenuMaker.Api.Authentication;
using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Api.Services;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if ((await _groceriesService.GetGroceryById(id)) is GroceryReponseModel grocery)
            return Ok(grocery);
        return NotFound();
    }

    [HttpPost]
    [ApiKey]
    public async Task<IActionResult> AddGrocery([FromBody] GroceryRequestModel grocery)
    {
        var groceryModel = GroceryMapper.MapToGroceryModel(grocery);
        var newGrocery = await _groceriesService.AddGrocery(groceryModel);
        return Created(newGrocery.Id.ToString(), GroceryMapper.MapToGroceryReponseModel(newGrocery));
    }

    [HttpPut]
    [ApiKey]
    [Route("{id:int}")]
    public async Task<IActionResult> EditGrocery([FromRoute] Guid id, [FromBody] GroceryRequestModel grocery)
    {
        if (grocery.Id != id)
            return BadRequest();

        var groceryModel = GroceryMapper.MapToGroceryModel(grocery);
        var updatedGrocery = await _groceriesService.UpdateGrocery(groceryModel);
        return Ok(GroceryMapper.MapToGroceryReponseModel(updatedGrocery));
    }

    [HttpDelete]
    [ApiKey]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteGrocery(Guid id)
    {
        await _groceriesService.DeleteGrocery(id);
        return Ok();
    }

    [HttpGet]
    [Route("categories")]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _groceriesService.GetGroceryCategories());
    }

}
