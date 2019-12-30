using System.Collections.Generic;
using Domain.Common.Filters;

namespace Domain.RecipesDetails.Filters.FiltersCriteria
{
	public struct RecipeSearchFilterCriteria : IFilterCriteria
	{
		public int? Requirements { get; set; }
		public int? NotAllowedAllergens { get; set; }
		public int? AllowedMealTypes { get; set; }
		public RangeFilterCriteria? CaloriesRange { get; set; }
		public IDictionary<int?, RangeFilterCriteria?> MacroNutrientsQuantity { get; set; }
	}
}