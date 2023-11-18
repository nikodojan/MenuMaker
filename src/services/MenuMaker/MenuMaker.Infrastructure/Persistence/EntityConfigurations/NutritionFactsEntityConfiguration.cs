using MenuMaker.Domain.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class NutritionFactsEntityConfiguration : IEntityTypeConfiguration<NutritionFacts>
{
    public void Configure(EntityTypeBuilder<NutritionFacts> builder)
    {
        builder.OwnsOne(nf => nf.ServingSize);
    }
}
