using WhatShouldIEat.Administration.Domain.Common.Helpers;

namespace WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrints
{
	public static class CalorieCalculator
	{
		public static double CountCalorieFromMass(this MacroNutrient macroNutrient, double grams)
		{
			var attribute = AttributeHelper<MacroNutrient>.GetAttribute<MacroNutrientAttribute>(macroNutrient);
			return attribute.Calorie * grams;
		}
	}
}