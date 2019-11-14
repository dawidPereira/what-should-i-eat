using System;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.MacroComponent;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class RecipeIngredient
	{
		public RecipeIngredient(Ingredient ingredient, double quantity, double weight)
		{
			Id = new Id<RecipeIngredient>(Guid.NewGuid());
			Ingredient = ingredient;
			Quantity = quantity;
			Weight = weight;
		}
		
		public Id<RecipeIngredient> Id { get; private set; }
		public Ingredient Ingredient { get; private set; }
		public double Quantity { get; private set; }
		public double Weight { get; set; }
	}
}