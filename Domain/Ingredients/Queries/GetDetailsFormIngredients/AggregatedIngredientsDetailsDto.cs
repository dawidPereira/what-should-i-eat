using System.Collections.Generic;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public struct AggregatedIngredientsDetailsDto
	{
		public AggregatedIngredientsDetailsDto(double calories,
			Allergen allergens,
			Requirement requirements,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		public double Calories { get; set; }
		public Allergen Allergens { get; set; }
		public Requirement Requirements { get; set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; set; }

		public static AggregatedIngredientsDetailsDto FromIngredientsGramsCollection(
			IngredientsGramsCollection ingredientsGramsCollection)
		{
			var calories = ingredientsGramsCollection.CalculateCalories();
			var allergens = ingredientsGramsCollection.GetAllergens();
			var requirements = ingredientsGramsCollection.GetRequirements();
			var macroNutrientQuantity = ingredientsGramsCollection.GetMacroNutrientQuantity();

			return new AggregatedIngredientsDetailsDto(calories, allergens, requirements, macroNutrientQuantity);
		}
	}
}