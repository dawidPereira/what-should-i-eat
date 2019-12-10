using System.Collections.Generic;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Filters.FiltersCriteria
{
	public class RecipeSearchFilterCriteria
	{
		public Requirement Requirements { get; set; }
		public Allergen NotAllowedAllergens { get; set; }
		public MealType AllowedMealTypes { get; set; }
		public RangeFilterCriteria CaloriesRange { get; set; }
		public IDictionary<MacroNutrient, RangeFilterCriteria?> MacroNutrientsQuantity { get; set; }
	}
}