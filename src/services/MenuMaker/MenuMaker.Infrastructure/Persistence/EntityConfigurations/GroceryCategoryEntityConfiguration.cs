using MenuMaker.Infrastructure.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Infrastructure.Persistence.EntityConfigurations;
internal class GroceryCategoryEntityConfiguration : IEntityTypeConfiguration<GroceryCategory>
{
    public void Configure(EntityTypeBuilder<GroceryCategory> builder)
    {
        builder.ToTable("GroceryCategories");

        builder
            .HasOne<GroceryCategory>(gc => gc.ParentCategory)
            .WithMany()
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
