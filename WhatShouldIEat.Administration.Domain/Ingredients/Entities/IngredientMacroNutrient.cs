using System;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class IngredientMacroNutrient
	{
		public IngredientMacroNutrient()
		{
		}
		
		public Guid Id { get; private set; }
		public Ingredient Ingredient { get; private set; }
		public MacroNutrient MacroNutrient { get; set; }
		public double ParticipationInIngredient { get; set; }
	}
}