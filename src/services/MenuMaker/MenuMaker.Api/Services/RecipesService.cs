using MenuMaker.Api.DTOs;
using MenuMaker.Api.Mapper;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;

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

    public async Task<IEnumerable<RecipeResponseModel>> GetRecipes(ISpecification<Recipe> spec)
    {
        var recipes = await _recipesRepository.FindWithSpecification(spec);
        var mapper = new RecipeMapper();
        
        var recipeResponseModels = recipes.Select(r=> mapper.ToRecipeResponseModel(r));

        return recipeResponseModels;
    }

    public async Task<double> GetCalories(int id)
    {
        //return await _recipesRepository.GetCaloriesForRecipe(id);
        throw new NotImplementedException();
    }
}
