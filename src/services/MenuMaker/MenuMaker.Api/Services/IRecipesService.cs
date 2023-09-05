using MenuMaker.Api.DTOs;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Infrastructure.Repositories.Specifications;

namespace MenuMaker.Api.Services;
public interface IRecipesService
{
    Task<IEnumerable<RecipeDto>> GetRecipes(ISpecification<Recipe> spec);
    Task<double> GetCalories(int id);
}