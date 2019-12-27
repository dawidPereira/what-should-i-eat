using System;

namespace Infrastructure.Entities.Recipe
{
	public class RecipeIngredient
	{
		public Guid RecipeId { get; set; }
		public Guid IngredientId { get; set; }
		public double Grams { get; set; }
	}
}