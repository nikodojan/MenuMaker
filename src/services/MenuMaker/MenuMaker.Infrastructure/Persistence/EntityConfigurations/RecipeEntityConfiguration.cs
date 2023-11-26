using MenuMaker.Infrastructure.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.HasKey(x => x.Id);

        builder
            .HasMany<Ingredient>(r => r.Ingredients)
        .WithOne()
        .HasForeignKey(i=>i.RecipeId);
    }
}
