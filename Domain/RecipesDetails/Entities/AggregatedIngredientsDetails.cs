using System.Collections.Generic;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.RecipesDetails.Entities
{
	public class AggregatedIngredientsDetails
	{
		public AggregatedIngredientsDetails(double calories,
			Allergen allergens,
			Requirement requirements,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		public double Calories { get; private set; }
		public Allergen Allergens { get; private set; }
		public Requirement Requirements { get; private set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; private set; }
	}
}