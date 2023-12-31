﻿using MenuMaker.Api.DTOs;
using MenuMaker.Api.Mapper;
using MenuMaker.Domain.Filters;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Domain.Models.ValueObjects;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Api.Services;

public class RecipesService : IRecipesService
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUnitOfWork<RecipesContext> _unitOfWork;

    public RecipesService(
        IRecipesRepository recipesRepository, 
        IUnitOfWork<RecipesContext> unitOfWork)
    {
        _recipesRepository = recipesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RecipeResponseModel> GetRecipeById(int id)
    {
        var recipe = await _recipesRepository.GetRecipe(id);
        var recipeResponse = RecipeMapper.MapToRecipeResponseModel(recipe);
        recipeResponse.NutritionFacts = NutritionFactsMapper.ToValuesReponseModel(CalculateNutritionFactsForRecipe(recipe));
        return recipeResponse;
    }

    public async Task<IEnumerable<RecipeResponseModel>> GetRecipes(bool includeIngredients, int skip, int take)
    {
        // Nutrition facts should be fetched and calculated in any case
        // TODO: Create a spec that does that, even when include ingredients is false
        // But then it fetches ingredients anyways, so just always fetch?
        // Or live without NF 

        var filter = new RecipeFilter(includeIngredients, skip, take);

        var recipes = await _recipesRepository.GetRecipesWithFilter(filter);
        var recipeResponseModels = recipes.Select(r => RecipeMapper.MapToRecipeResponseModel(r)).ToList();

        if (includeIngredients)
        {
            foreach (var r in recipes)
            {
                var newNf = CalculateNutritionFactsForRecipe(r);
                var mapped = NutritionFactsMapper.ToValuesReponseModel(newNf);
                recipeResponseModels.Where(rm => rm.Id == r.Id).Single().NutritionFacts = mapped;
            }
        }

        return recipeResponseModels;
    }

    private NutritionFacts CalculateNutritionFactsForRecipe(Recipe recipe)
    {
        if (recipe == null) return null;
        if (!recipe.Ingredients.Any()) return null;

        var newNf = new NutritionFacts();
        foreach (var ingr in recipe.Ingredients)
        {
            var calc = ingr.Grocery.NutritionFacts?.CalculateForServingSize(ingr.Amount ?? 0);
            newNf += calc ?? new NutritionFacts();
        }
        var servingSize = new UnitValue("Recipe", 1);
        newNf.ServingSize = servingSize;
        return newNf;
    }

    public async Task<double> GetCalories(int id)
    {
        //return await _recipesRepository.GetCaloriesForRecipe(id);
        throw new NotImplementedException();
    }
}
