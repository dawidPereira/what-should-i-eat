﻿using System;

namespace Domain.RecipesDetails.Ingredients.Entities.MacroNutrients
{
	public class MacroNutrientAttribute : Attribute
	{
		internal MacroNutrientAttribute(double calorie) => Calorie = calorie;
		public double Calorie { get; private set; }
	}
}