using System.Collections.Generic;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Queries.GetDetailsFormIngredients
{
	public struct AggregatedIngredientsDetailsDto
	{
		public AggregatedIngredientsDetailsDto(double calories,
			int allergens,
			int requirements,
			IDictionary<int, double> macroNutrientQuantity)
		{
			Calories = calories;
			Allergens = allergens;
			Requirements = requirements;
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		public double Calories { get; }
		public int Allergens { get; }
		public int Requirements { get; }
		public IDictionary<int, double> MacroNutrientQuantity { get; }

		public static AggregatedIngredientsDetailsDto FromIngredientsGramsCollection(
			IngredientsGramsCollection ingredientsGramsCollection)
		{
			var calories = ingredientsGramsCollection.CalculateCalories();
			var allergens = ingredientsGramsCollection.GetAllergens();
			var requirements = ingredientsGramsCollection.GetRequirements();
			var macroNutrientQuantity = ingredientsGramsCollection.GetMacroNutrientQuantity();

			return new AggregatedIngredientsDetailsDto(calories, (int)allergens, (int)requirements, macroNutrientQuantity);
		}
	}
}