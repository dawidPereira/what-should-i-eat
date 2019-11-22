using System;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Guid ingredientId, Guid recipeId, double grams)
		{
			IngredientId = ingredientId;
			RecipeId = recipeId;
			Grams = grams;
		}

		public Guid IngredientId { get; private set; }
		public Ingredient Ingredient { get; private set; }
		public Guid RecipeId { get; private set; }
		private Recipe Recipe { get; set; }
		public double Grams { get; private set; }
	}
}