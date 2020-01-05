using System.Collections.Generic;
using Domain.Common.Filters;

namespace Domain.RecipesDetails.Filters.FiltersCriteria
{
	public struct RecipeSearchFilterCriteria : IFilterCriteria
	{
		public RecipeSearchFilterCriteria(int? requirements,
			int? notAllowedAllergens,
			int? allowedMealTypes,
			RangeFilterCriteria? caloriesRange,
			IDictionary<int, RangeFilterCriteria> macroNutrientsQuantity)
		{
			Requirements = requirements;
			NotAllowedAllergens = notAllowedAllergens;
			AllowedMealTypes = allowedMealTypes;
			CaloriesRange = caloriesRange;
			MacroNutrientsQuantity = macroNutrientsQuantity;
		}
		public int? Requirements { get; }
		public int? NotAllowedAllergens { get; }
		public int? AllowedMealTypes { get; }
		public RangeFilterCriteria? CaloriesRange { get; }
		public IDictionary<int, RangeFilterCriteria> MacroNutrientsQuantity { get; }
	}
}