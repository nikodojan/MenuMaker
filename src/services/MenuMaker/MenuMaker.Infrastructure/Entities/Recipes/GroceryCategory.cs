
namespace MenuMaker.Infrastructure.Entities.Recipes;

public class GroceryCategory : Entity<int>
{
    public string Name { get; set; }

    public GroceryCategory? ParentCategory { get; set; }
}


