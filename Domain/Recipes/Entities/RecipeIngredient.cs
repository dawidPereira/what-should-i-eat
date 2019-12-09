using System;
using Domain.Ingredients.Entities;

namespace Domain.Recipes.Entities
{
	public class RecipeIngredient
	{
		private RecipeIngredient()
		{
		}
		
		public RecipeIngredient(Guid ingredientId, Guid recipeId, double grams, Ingredient ingredient = null)
		{
			IngredientId = ingredientId;
			RecipeId = recipeId;
			Grams = grams;
			Ingredient = ingredient;
		}

		public Guid IngredientId { get; private set; }
		public virtual Ingredient Ingredient { get; private set; }
		public Guid RecipeId { get; private set; }
		public double Grams { get; private set; }
		public virtual Recipe Recipe { get; private set; }
	}
}