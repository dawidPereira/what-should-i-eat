using System;

namespace WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrient
{
	public class MacroNutrientAttribute : Attribute
	{
		internal MacroNutrientAttribute(double calorie) => Calorie = calorie;
		public double Calorie { get; private set; }
	}
}