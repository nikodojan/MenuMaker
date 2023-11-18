using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using MenuMaker.Infrastructure.Repositories.Specifications;
using System.Linq.Expressions;

namespace MenuMaker.Api.Tests.Stubs;
internal class RecipesRepositoryStub : GenericRepositoryStub<Recipe, int, RecipesContext>, IRecipesRepository
{
    public Task<double> GetCaloriesForRecipe(int id)
    {
        throw new NotImplementedException();
    }
}
