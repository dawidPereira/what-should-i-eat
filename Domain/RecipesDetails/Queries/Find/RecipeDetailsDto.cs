using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Queries.Find
{
	public class RecipeDetailsDto
	{
		private RecipeDetailsDto(Guid id, string name, int requirements, int allergens, int mealTypes, double calories, IDictionary<int, double> macroNutrientQuantity)
		{
			Id = id;
			Name = name;
			Requirements = requirements;
			Allergens = allergens;
			MealTypes = mealTypes;
			Calories = calories;
			MacroNutrientQuantity = macroNutrientQuantity;
		}
		
		public Guid Id { get; }
		public string Name { get; }	
		public int Requirements { get; }
		public int Allergens { get; }
		public int MealTypes { get; }
		public double Calories { get; }
		public IDictionary<int, double> MacroNutrientQuantity { get; }

		public static RecipeDetailsDto FromRecipeDetails(RecipeDetails recipesDetails) =>
			new RecipeDetailsDto(recipesDetails.Id.Value,
				recipesDetails.Name,
				recipesDetails.Requirements,
				recipesDetails.Allergens,
				recipesDetails.MealTypes,
				recipesDetails.Calories,
				recipesDetails.MacroNutrientQuantity);
	}
}