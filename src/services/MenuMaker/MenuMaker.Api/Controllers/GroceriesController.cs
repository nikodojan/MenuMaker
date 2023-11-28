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
        //var spec = new BaseSpecification<Grocery>();
        //spec.AddInclude(q => q.Include(g=>g.Category));
        //spec.AddInclude(q => q.Include(g => g.NutritionFacts));
        //var result = await _groceriesRepo.FindWithSpecification(spec);
        //var mapper = new GroceryMapper();
        //var res = new List<GroceryReponseModel>();
        //foreach (var item in result)
        //{
        //    res.Add(mapper.ToGroceryReponseModel(item));
        //}

        return Ok(await _groceriesService.GetAllGroceries());
    }

}
