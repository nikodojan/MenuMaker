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

        builder.Property<int>(r => r.Portions).IsRequired().HasDefaultValue<int>(1);

        builder.OwnsOne(r => r.Instructions, i=>i.ToJson());

        builder.Property(r=>r.Instructions).HasDefaultValue(new Dictionary<string, List<string>>()
        {
            { "", new List<string>() { "Step1" } }
        });
    }
}
