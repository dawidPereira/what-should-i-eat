using System.Collections.Generic;

namespace Domain.RecipesDetails.Entities
{
	public class AggregatedIngredientsDetails
	{
		public AggregatedIngredientsDetails(double calories,
			int allergens,
			int requirements,
			IDictionary<int, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		public double Calories { get; private set; }
		public int Allergens { get; private set; }
		public int Requirements { get; private set; }
		public IDictionary<int, double> MacroNutrientQuantity { get; private set; }
	}
}