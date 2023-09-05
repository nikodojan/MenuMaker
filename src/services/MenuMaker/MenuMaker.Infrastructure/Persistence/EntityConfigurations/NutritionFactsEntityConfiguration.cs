using MenuMaker.Domain.Aggregates.RecipeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class NutritionFactsEntityConfiguration : IEntityTypeConfiguration<NutritionFacts>
{
    public void Configure(EntityTypeBuilder<NutritionFacts> builder)
    {
        builder.OwnsOne(nf => nf.Calories);
        builder.OwnsOne(nf => nf.Fat);
        builder.OwnsOne(nf => nf.Carbonhydrates);
        builder.OwnsOne(nf => nf.Sugar);
        builder.OwnsOne(nf => nf.Protein);
        builder.OwnsOne(nf => nf.ServingSize);
    }
}
