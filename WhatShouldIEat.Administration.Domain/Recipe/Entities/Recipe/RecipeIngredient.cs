using System;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Ingredient.Entities.Ingredient ingredient, double quantity, double grams)
		{
			Id = new Id<RecipeIngredient>(Guid.NewGuid());
			Ingredient = ingredient;
			Quantity = quantity;
			Grams = grams;
		}
		
		public Id<RecipeIngredient> Id { get; private set; }
		public Ingredient.Entities.Ingredient Ingredient { get; private set; }
		public double Quantity { get; private set; }
		public double Grams { get; private set; }
	}
}