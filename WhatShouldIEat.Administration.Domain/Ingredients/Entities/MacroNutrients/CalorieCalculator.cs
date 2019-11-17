using WhatShouldIEat.Administration.Domain.Common.Helpers;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients
{
	public static class CalorieCalculator
	{
		public static double CalculateCalories(this MacroNutrient macroNutrient, double grams)
		{
			var attribute = AttributeHelper<MacroNutrient>.GetAttribute<MacroNutrientAttribute>(macroNutrient);
			return attribute.Calorie * grams;
		}
	}
}