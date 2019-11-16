using WhatShouldIEat.Administration.Domain.Common.Helpers;

namespace WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrient
{
	public static class CalorieCalculator
	{
		public static double CountCalorie(this MacroNutrient macroNutrient, double grams)
		{
			var attribute = AttributeHelper<MacroNutrient>.GetAttribute<MacroNutrientAttribute>(macroNutrient);
			return attribute.Calorie * grams;
		}
	}
}