using System;

namespace Domain.Ingredients.Entities.MacroNutrients
{
	public class MacroNutrientAttribute : Attribute
	{
		internal MacroNutrientAttribute(double calorie) => SetCalorie(calorie);
		public double Calorie { get; private set; }

		private void SetCalorie(double calorie)
		{
			if (calorie <= 0  || calorie > 10)
				throw new ArgumentException("Calorie must be bigger than zero and lower than ten.");
			Calorie = calorie;
		}
	}
}