using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class IngredientMacroNutrient
	{
		private Ingredient Ingredient { get; set; }
		public MacroNutrient MacroNutrient { get; set; }
		public double ParticipationInIngredient { get; set; }
	}
}