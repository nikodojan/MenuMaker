using MenuMaker.Api.DTOs;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using Riok.Mapperly.Abstractions;

namespace MenuMaker.Api.Mapper;

[Mapper]
public partial class RecipeDtoMapper
{
    public partial RecipeDto RecipeToRecipeDto(Recipe recipe);
}
