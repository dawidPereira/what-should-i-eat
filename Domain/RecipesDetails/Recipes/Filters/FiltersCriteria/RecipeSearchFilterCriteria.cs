using System.Collections.Generic;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;
using Domain.RecipesDetails.Recipes.Entities;

namespace Domain.RecipesDetails.Recipes.Filters.FiltersCriteria
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