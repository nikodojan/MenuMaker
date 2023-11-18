using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MenuMaker.Api.Services;

public class GroceriesListService : IGroceriesListService
{
    private readonly IRecipesRepository _recipesRepository;

    public GroceriesListService(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<int> recipeIds)
    {
        var ingredients = new List<Ingredient>();

        foreach (int id in recipeIds)
        {
            var spec = new BaseSpecification<Recipe>(recipe => recipe.Id == id);
            spec.AddInclude(q =>
                q.Include(r => r.Ingredients)
                    .ThenInclude(i => i.Grocery)
                    .ThenInclude(g => g.Category)
                );

            var recipes = await _recipesRepository.FindWithSpecification(spec);

            if (recipes.Any() && recipes.First() != null)
            {
                ingredients.AddRange(recipes.First().Ingredients);
            }  
        }

        var groupedByGrocery = ingredients.GroupBy(
            keySelector: e => e.Grocery,
            elementSelector: e => e,
            resultSelector: (key, value) => new { Grocery = key, Selection = value })
            .ToDictionary(e => e.Grocery, e => e.Selection);

        var groupedByGroceryAndUnit = new Dictionary<Grocery, Dictionary<string?, IEnumerable<Ingredient>>?>();

        foreach (var e in groupedByGrocery)
        {
            var byUnit = e.Value
                .GroupBy(
                    i => i.Unit,
                    e => e,
                    resultSelector: (key, value) => new { Grocery = key, Selection = value })
                .ToDictionary(e => e.Grocery, e => e.Selection);

            groupedByGroceryAndUnit.Add(e.Key, byUnit);
        }

        var resultList = new List<GroceryListItem>();

        foreach (var grocery in groupedByGroceryAndUnit)
        {
            foreach (var unit in grocery.Value)
            {
                var sum = unit.Value.Sum(v => v.Amount);
                var rec = new GroceryListItem(grocery.Key.NameSelectable, sum, unit.Key);
                resultList.Add(rec);
            }
        }

        return resultList;
    }
}
