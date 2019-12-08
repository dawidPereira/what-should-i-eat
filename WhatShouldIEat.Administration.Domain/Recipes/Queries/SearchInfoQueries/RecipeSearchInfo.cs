using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries
{
	public class RecipeSearchInfo
	{
		public RecipeSearchInfo(Guid id,
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

		public Guid Id { get; private set; }
		public Requirement Requirements { get; private set; }
		public Allergen Allergens { get; private set; }
		public MealType MealTypes { get; private set; }
		public double Calories { get; private set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; private set; }
	}
}