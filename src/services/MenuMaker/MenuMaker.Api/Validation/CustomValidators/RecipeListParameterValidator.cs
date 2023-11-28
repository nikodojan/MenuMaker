using FluentValidation;
using MenuMaker.Api.Validation.CustomValidators;

namespace MenuMaker.Api.Validations.CustomValidators;

public class RecipeListParameterValidator
{
    public async Task<RecipeListParamaterValidationResult> Validate(string list)
    {
        var trimmed = list.TrimStart('[').TrimEnd(']');

        if((list.Length - trimmed.Length) != 2)
            return new RecipeListParamaterValidationResult(false, "The recipe id list was not in the right format.", null);

        var numberStrings = trimmed.Split(',');

        var recipes = new List<(int, int)>();

        foreach (var recipePortionPair in numberStrings)
        {
            var values = recipePortionPair.Split(':');
            if (values.Length != 2)
                return new RecipeListParamaterValidationResult(false, $"The submittet recipeId:portion pair {values} is not in a valid format.", null);

            try
            {
                var recipeId = Convert.ToInt32(values[0]);
                var portions = Convert.ToInt32(values[1]);
                recipes.Add((recipeId, portions));
            }
            catch (FormatException)
            {
                return new RecipeListParamaterValidationResult(false, $"One of the values in {recipePortionPair}is not a number", null);
            }
            catch (OverflowException)
            {
                return new RecipeListParamaterValidationResult(false, $"One of the values in {recipePortionPair} is not a number", null);
            }
        }

        return new RecipeListParamaterValidationResult(true, null, recipes);
    }
}
