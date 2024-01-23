namespace MenuMaker.Domain.Models.Groceries;

public class GroceryCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public GroceryCategory? ParentCategory { get; set; } = null;
}


