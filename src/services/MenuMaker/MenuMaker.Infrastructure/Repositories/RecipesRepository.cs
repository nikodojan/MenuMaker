
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Infrastructure.Repositories;
public class RecipesRepository : GenericRepository<Recipe, int, RecipesContext>, IRecipesRepository
{
    public RecipesRepository(RecipesContext context) : base(context)
    {

    }

    public async Task<double> GetCaloriesForRecipe(int id)
    {
        var result = _dbContext.Recipes
            .AsNoTracking().Where(r => r.Id == id)
            .Include(r => r.Ingredients)
            .ThenInclude(i => i.Grocery)
            .ThenInclude(g => g.NutritionFacts)
            .SelectMany(r =>
                r.Ingredients.Select(i =>
                    i.Grocery.NutritionFacts.Calories.Amount)).Sum();
        return result;
    }
}
