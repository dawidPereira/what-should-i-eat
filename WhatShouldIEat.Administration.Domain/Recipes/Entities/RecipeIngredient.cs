using System;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Entities
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
		public Ingredient Ingredient { get; private set; }
		public Guid RecipeId { get; private set; }
		public double Grams { get; private set; }
		public Recipe Recipe { get; private set; }
	}
}