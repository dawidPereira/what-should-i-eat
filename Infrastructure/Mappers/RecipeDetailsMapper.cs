using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Recipes.Queries.GetById;
using Domain.RecipesDetails.Entities;

namespace Infrastructure.Mappers
{
	public class RecipeDetailsMapper : IRecipeDetailsMapper
	{
		public Recipe RecipeFromDto(RecipeDto dto)
		{
			var recipeInfo = new RecipeInfo(dto.RecipeInfo.DifficultyLevel,
				dto.RecipeInfo.PreparationTime,
				dto.RecipeInfo.ApproximateCost,
				dto.RecipeInfo.MealTypes);
			return new Recipe(dto.Id, dto.Name, dto.Description, recipeInfo, dto.RecipeIngredients);
		}
		
		public AggregatedIngredientsDetails AggregatedIngredientsDetailsFromDto(AggregatedIngredientsDetailsDto dto) =>
			new AggregatedIngredientsDetails(dto.Calories, dto.Allergens, dto.Requirements, dto.MacroNutrientQuantity);
	}
}