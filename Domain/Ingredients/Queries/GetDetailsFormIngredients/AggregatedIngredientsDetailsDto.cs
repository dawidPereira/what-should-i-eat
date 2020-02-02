using System.Collections.Generic;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public struct AggregatedIngredientsDetailsDto
	{
		public AggregatedIngredientsDetailsDto(double calories,
			Allergen allergens,
			Requirement requirements,
			IDictionary<string, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens.ToString();
			Requirements = requirements.ToString();
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		public double Calories { get; }
		public string Allergens { get; }
		public string Requirements { get; }
		public IDictionary<string, double> MacroNutrientQuantity { get; }

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