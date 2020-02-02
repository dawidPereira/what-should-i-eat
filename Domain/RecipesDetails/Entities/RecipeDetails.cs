using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;

namespace Domain.RecipesDetails.Entities
{
	[Serializable]
	public struct RecipeDetails
	{
		private RecipeDetails(Identity<Guid> id,
			string name,
			Requirement requirements,
			Allergen allergens,
			MealType mealTypes,
			double calories,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Id = id;
			Name = name;
			Requirements = requirements;
			Allergens = allergens;
			MealTypes = mealTypes;
			Calories = calories;
			MacroNutrientQuantity = macroNutrientQuantity;
		}

		public static RecipeDetails FromRecipeAndIngredientsDetails(Recipe recipe,
			AggregatedIngredientsDetails ingredientsDetails) =>
			new RecipeDetails(recipe.Id,
				recipe.Name,
				ingredientsDetails.Requirements,
				ingredientsDetails.Allergens,
				recipe.RecipeInfo.MealTypes,
				ingredientsDetails.Calories,
				ingredientsDetails.MacroNutrientQuantity);

		public Identity<Guid> Id { get; }
		public string Name { get; }
		public Requirement Requirements { get; }
		public Allergen Allergens { get; }
		public MealType MealTypes { get; }
		public double Calories { get; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; }
	}
}