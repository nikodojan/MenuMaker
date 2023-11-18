using MenuMaker.Api.Mapper;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuMaker.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class GroceriesController : ControllerBase
{
    private readonly IGenericRepository<Grocery, int> _groceriesRepo;

    public GroceriesController(IGenericRepository<Grocery, int> groceriesRepo)
    {
        _groceriesRepo = groceriesRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var spec = new BaseSpecification<Grocery>();
        spec.AddInclude(q => q.Include(g=>g.Category));
        //spec.AddInclude(q => q.Include(g => g.NutritionFacts));
        var result = await _groceriesRepo.FindWithSpecification(spec);
        //var mapper = new GroceryMapper();
        //var res = new List<GroceryReponseModel>();
        //foreach (var item in result)
        //{
        //    res.Add(mapper.ToGroceryReponseModel(item));
        //}
        
        return Ok();
    }

    // GET api/<GroceriesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<GroceriesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<GroceriesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<GroceriesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
