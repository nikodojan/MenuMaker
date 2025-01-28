using MenuMaker.Infrastructure.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder
            .HasMany<Ingredient>(r => r.Ingredients)
            .WithOne()
            .HasForeignKey(i=>i.RecipeId);

        builder.Property<string>(r => r.Title).IsRequired();

        builder.Property<int>(r => r.Portions).IsRequired().HasDefaultValue<int>(1);

        builder.Property(r => r.Instructions).HasColumnType("jsonb")
            .HasConversion(
                i => JsonSerializer.Serialize(i, (JsonSerializerOptions)null),
                i => JsonSerializer.Deserialize<Dictionary<string, List<string>>>(i, (JsonSerializerOptions)null));
    }
}
