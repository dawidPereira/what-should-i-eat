using System;

namespace Domain.Ingredients.Entities.MacroNutirents
{
	public class MacroNutrientAttribute : Attribute
	{
		internal MacroNutrientAttribute(double calorie) => Calorie = calorie;
		public double Calorie { get; private set; }
	}
}