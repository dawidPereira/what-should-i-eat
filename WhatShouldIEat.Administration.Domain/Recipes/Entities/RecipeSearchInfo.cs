using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Recipes.Entities
{
	public class RecipeSearchInfo
	{
		public Requirement Requirements { get; set; }
		public Allergen Allergens { get; set; }
		public MealType MealTypes { get; set; }
		public double Calories { get; set; }
		public IDictionary<MacroNutrient, double> MacroNutrientQuantity { get; set; }
	}
}