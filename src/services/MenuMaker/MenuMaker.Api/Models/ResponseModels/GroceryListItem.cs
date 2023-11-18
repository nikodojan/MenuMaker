namespace MenuMaker.Api.Models.ResponseModels;

public class GroceryListItem
{
    public GroceryListItem()
    {
            
    }

    public GroceryListItem(string groceryName, double? amount, string? unit)
    {
        GroceryName = groceryName;
        Amount = amount;
        Unit = unit;
    }

    public string GroceryName { get; set; }
    public double? Amount { get; set; }
    public string? Unit { get; set; }
}
