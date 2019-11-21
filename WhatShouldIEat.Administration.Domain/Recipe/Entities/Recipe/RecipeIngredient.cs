using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Id<Ingredient> ingredientId, Id<Recipe> recipeId, double grams)
		{
			IngredientId = ingredientId;
			RecipeId = recipeId;
			Grams = grams;
		}

		public Id<Ingredient> IngredientId { get; private set; }
		public Ingredient Ingredient { get; set; }
		public Id<Recipe> RecipeId { get; private set; }
		private Recipe Recipe { get; set; }
		public double Grams { get; private set; }
	}
}