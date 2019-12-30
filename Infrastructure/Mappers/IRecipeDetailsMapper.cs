using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetById;
using Domain.RecipesDetails.Entities;

namespace Infrastructure.Mappers
{
	public interface IRecipeDetailsMapper
	{
		Recipe RecipeFromDto(RecipeDto dto);

		AggregatedIngredientsDetails AggregatedIngredientsDetailsFromDto(AggregatedIngredientsDetailsDto dto);
	}
}