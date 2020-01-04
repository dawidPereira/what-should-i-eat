using System;

namespace Domain.Recipes.Dtos
{
	public class RecipeIngredientDto
	{
		public RecipeIngredientDto(Guid ingredientId, double grams)
		{
			IngredientId = ingredientId;
			Grams = grams;
		}
		
		public Guid IngredientId { get; }
		public double Grams { get; }
	}
}