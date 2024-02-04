using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ingredient = MenuMaker.Infrastructure.Entities.Recipes.Ingredient;
using Grocery = MenuMaker.Infrastructure.Entities.Recipes.Grocery;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class IngredientEntityConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");

        builder.HasKey(x => x.Id);

        builder
            .HasOne<Grocery>(i => i.Grocery)
            .WithMany()
            .HasForeignKey(i=>i.GroceryId);
    }
}
