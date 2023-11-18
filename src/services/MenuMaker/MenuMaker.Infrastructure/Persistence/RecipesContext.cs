using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Infrastructure.Persistence;
public class RecipesContext : DbContext, IUnitOfWork<RecipesContext>
{
    public RecipesContext(DbContextOptions<RecipesContext> options)
        :base (options)
    {
        
    }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new RecipeEntityConfiguration().Configure(modelBuilder.Entity<Recipe>());
        new IngredientEntityConfiguration().Configure(modelBuilder.Entity<Ingredient>());
        new GroceryEntityConfiguration().Configure(modelBuilder.Entity<Grocery>());
        new GroceryCategoryEntityConfiguration().Configure(modelBuilder.Entity<GroceryCategory>());
        new NutritionFactsEntityConfiguration().Configure(modelBuilder.Entity<NutritionFacts>());
    }

    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }
}
