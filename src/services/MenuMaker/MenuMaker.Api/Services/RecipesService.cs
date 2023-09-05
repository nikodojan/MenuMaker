using MenuMaker.Api.DTOs;
using MenuMaker.Api.Mapper;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;

namespace MenuMaker.Api.Services;

public class RecipesService : IRecipesService
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUnitOfWork<RecipesContext> _unitOfWork;

    public RecipesService(IRecipesRepository recipesRepository, IUnitOfWork<RecipesContext> unitOfWork)
    {
        _recipesRepository = recipesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecipeDto>> GetRecipes(ISpecification<Recipe> spec)
    {
        var recipes = await _recipesRepository.FindWithSpecification(spec);
        var mapper = new RecipeDtoMapper();
        
        var dtos = recipes.Select(r=> mapper.RecipeToRecipeDto(r));

        return dtos;
    }

    public async Task<double> GetCalories(int id)
    {
        return await _recipesRepository.GetCaloriesForRecipe(id);
    }
}
