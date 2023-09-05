using MenuMaker.Domain.Aggregates.RecipeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class GroceryEntityConfiguration : IEntityTypeConfiguration<Grocery>
{
    public void Configure(EntityTypeBuilder<Grocery> builder)
    {
        builder.ToTable("Groceries");

        builder
            .HasOne<NutritionFacts>(g => g.NutritionFacts)
            .WithOne();

        builder
            .HasOne<GroceryCategory>(g=>g.Category)
            .WithMany();
    }
}
