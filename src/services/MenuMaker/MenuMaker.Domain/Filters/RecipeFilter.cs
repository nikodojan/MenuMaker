namespace MenuMaker.Domain.Filters;
public class RecipeFilter
{
    public RecipeFilter()
    {
            
    }

    public RecipeFilter(bool includeIngredients, int skip, int take, string? name = null)
    {
        IncludeIngredients = includeIngredients;
        Skip = skip;
        Take = take;
        Name = name;
    }

    public string? NameCriteria { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public string? Name { get; }
    public bool IncludeIngredients { get; set; } = false;
}
