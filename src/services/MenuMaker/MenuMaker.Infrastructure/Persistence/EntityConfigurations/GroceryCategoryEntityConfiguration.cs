using MenuMaker.Infrastructure.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class GroceryCategoryEntityConfiguration : IEntityTypeConfiguration<GroceryCategory>
{
    public void Configure(EntityTypeBuilder<GroceryCategory> builder)
    {
        builder.ToTable("GroceryCategories");
    }
}
