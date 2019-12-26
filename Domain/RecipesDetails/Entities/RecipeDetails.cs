using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;

namespace Domain.RecipesDetails.Entities
{
	public class RecipeDetails
	{
		public RecipeDetails(Identity<Guid> id,
			Requirement requirements,
			Allergen allergens,
			MealType mealTypes,
			double calories,
			IDictionary<MacroNutrient, double> macroNutrientQuantity)
		{
			Id = id;
			Requirements = requirements;
			Allergens = allergens;
			MealTypes = mealTypes;
			Calories = calories;
			MacroNutrientQuantity = macroNutrientQuantity;
		}

		public Identity<Guid> Id { get; private set; }
		public string Name { get; private set; }	
		public Requirement Requirements { get; private set; }
		public Allergen Allergens { get; private set; }
		public MealType MealTypes { get; private set; }
		public double Calories { get; private set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; private set; }
	}
}