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

        var ids = new List<int>();

        foreach (var id in numberStrings)
        {
            try
            {
                ids.Add(Convert.ToInt32(id));
            }
            catch (FormatException)
            {
                return new RecipeListParamaterValidationResult(false, $"{id} is not numbers", null);
            }
            catch (OverflowException)
            {
                return new RecipeListParamaterValidationResult(false, $"{id} is not numbers", null);
            }
        }

        return new RecipeListParamaterValidationResult(true, null, ids);
    }
}
