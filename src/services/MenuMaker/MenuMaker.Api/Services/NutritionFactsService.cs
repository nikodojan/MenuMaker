using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Repositories;

namespace MenuMaker.Api.Services;

public class NutritionFactsService
{
    private readonly IGenericRepository<NutritionFacts, int> _nutritionFactsRepository;

    public NutritionFactsService(IGenericRepository<NutritionFacts, int> nutritionFactsRepository)
	{
        _nutritionFactsRepository = nutritionFactsRepository;
    }

    public async Task<NutritionFacts> GetNutritionFactsById(int id)
    {
        return await _nutritionFactsRepository.GetAsync(id, null);
    }

    public NutritionFacts GetNutritionFactsForRecipe(int recipeId)
    {
        throw new NotImplementedException();
    }

    public NutritionFacts GetNutritionFactsForMenu(int menuId)
    {
        throw new NotImplementedException();
    }
}
