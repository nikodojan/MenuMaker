using System.Linq.Expressions;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Domain.Common;

using MenuMaker.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Infrastructure.Repositories;

public interface IRecipesRepository : IGenericRepository<Recipe, int>
{
    Task<double> GetCaloriesForRecipe(int id);
}