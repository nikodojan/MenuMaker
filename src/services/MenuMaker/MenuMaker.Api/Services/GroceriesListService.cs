using MenuMaker.Api.Models.RequestModels;
using MenuMaker.Api.Models.ResponseModels;
using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Groceries;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Api.Services;

public class GroceriesListService : IGroceriesListService
{
    private readonly IRecipesRepository _recipesRepository;

    public GroceriesListService(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<GroceriesListRequestModel> listRequests)
    {
        var ingredients = new List<Ingredient>();

        foreach (var request in listRequests)
        {
            var recipe = await _recipesRepository.GetRecipe(request.RecipeId);
            var portionedIngredients = recipe.CalculateIngredientsByPortions(request.Portions);
            ingredients.AddRange(portionedIngredients);
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

    public async Task<IEnumerable<GroceryListItem>> GetGroceryList(IEnumerable<(int, short)> idPortionsTuples)
    {
        var recipesAndPortions = new List<GroceriesListRequestModel>();
        foreach (var tuple in idPortionsTuples)
        {
            recipesAndPortions.Add(new GroceriesListRequestModel(tuple.Item1, tuple.Item2));
        }

        return await GetGroceryList(recipesAndPortions);
    }
}
