using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuMaker.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NutritionFactsController : ControllerBase
{
    private readonly IGenericRepository<NutritionFacts, int> _nutritionFactsRepo;

    public NutritionFactsController(IGenericRepository<NutritionFacts, int> nutritionFactsRepo)
    {
        _nutritionFactsRepo = nutritionFactsRepo;
    }
    // GET: api/<NutritionFactsController>
    //[HttpGet]
    //public async Task<IActionResult> Get()
    //{
    //    var mapper = new NutritionFactsResponseMapper();

    //    var fact = (await _nutritionFactsRepo.GetAllAsync()).First();

    //    var resp = new GroceryNutritionFactsResponse()
    //    {
    //        Grocery = "Tomato",
    //        NutritionFacts = mapper.NutritionFactsToResponse(fact)
    //    };

    //    return Ok(resp);
    //}

    // GET api/<NutritionFactsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<NutritionFactsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<NutritionFactsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<NutritionFactsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
