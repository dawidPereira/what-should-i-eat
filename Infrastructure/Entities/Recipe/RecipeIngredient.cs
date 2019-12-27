using System;

namespace Infrastructure.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Guid recipeId, Guid ingredientId, double grams)
		{
			RecipeId = recipeId;
			IngredientId = ingredientId;
			Grams = grams;
		}
		public Guid RecipeId { get; set; }
		public Guid IngredientId { get; set; }
		public double Grams { get; set; }
	}
}