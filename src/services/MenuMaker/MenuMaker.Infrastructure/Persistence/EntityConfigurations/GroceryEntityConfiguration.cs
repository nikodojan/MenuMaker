using MenuMaker.Infrastructure.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class GroceryEntityConfiguration : IEntityTypeConfiguration<Grocery>
{
    public void Configure(EntityTypeBuilder<Grocery> builder)
    {

        const string NfPrefix = "NF_";
        builder.ToTable("Groceries");

        builder
            .OwnsOne<NutritionFacts>(g=>g.NutritionFacts,
            nf=>
            {
                nf.Property(p => p.Calories).HasColumnName(NfPrefix + nameof(NutritionFacts.Calories));
                nf.Property(p=>p.GrammsFat).HasColumnName(NfPrefix + nameof(NutritionFacts.GrammsFat));
                nf.Property(p => p.GrammsCarbonhydrates).HasColumnName(NfPrefix + nameof(NutritionFacts.GrammsCarbonhydrates));
                nf.Property(p => p.GrammsSugar).HasColumnName(NfPrefix + nameof(NutritionFacts.GrammsSugar));
                nf.Property(p => p.GrammsFiber).HasColumnName(NfPrefix + nameof(NutritionFacts.GrammsFiber));
                nf.Property(p => p.GrammsProtein).HasColumnName(NfPrefix + nameof(NutritionFacts.GrammsProtein));
                nf.OwnsOne(nf => nf.ServingSize,
                    s=>
                    {
                        s.Property(s => s.Amount).HasColumnName(NfPrefix + "Serving_" + nameof(NutritionFacts.ServingSize.Amount));
                        s.Property(s => s.Unit)
                            .HasColumnName(NfPrefix + "Serving_" + nameof(NutritionFacts.ServingSize.Unit))
                            .HasDefaultValue<string>("g");
                    });
            });

        builder
            .HasOne<GroceryCategory>(g=>g.Category)
            .WithMany();

        builder
            .Property<string>(nameof(Grocery.StandardUnit))
            .HasDefaultValue<string>("g");

        builder.HasIndex(g => g.NameSelectable).IsUnique();
    }
}
