namespace MenuMaker.Domain.Models.Recipes.ValueObjects;

public class UnitValue
{
    public UnitValue(string unit, double amount)
    {
        if (string.IsNullOrWhiteSpace(unit))
        {
            throw new ArgumentException($"'{nameof(unit)}' cannot be null or whitespace.", nameof(unit));
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException($"'{nameof(unit)}' cannot be less then 0.", nameof(unit));
        }

        Unit = unit;
        Amount = amount;
    }

    public UnitValue()
    {

    }

    public string Unit { get; init; }
    public double Amount { get; init; }
}
