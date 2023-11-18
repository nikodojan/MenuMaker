namespace MenuMaker.Api.Validation.CustomValidators;

public record RecipeListParamaterValidationResult(bool IsValid, string? Message, IEnumerable<int> RecipeIds)
{
}
