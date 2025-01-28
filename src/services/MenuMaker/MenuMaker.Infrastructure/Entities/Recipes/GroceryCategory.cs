
namespace MenuMaker.Infrastructure.Entities.Recipes;

public class GroceryCategory : Entity<Guid>
{
    public string Name { get; set; }

    public GroceryCategory? ParentCategory { get; set; }
}


