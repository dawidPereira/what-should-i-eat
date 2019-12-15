﻿using System.Collections.Generic;
using System.Linq;
using Domain.Common.Filters;
using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;
using Domain.RecipesDetails.Recipes.Filters.FiltersCriteria;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters
{
	public class MacroNutrientsFilter : IFilter<RecipeSearchInfo>
	{
		private readonly IDictionary<MacroNutrient, RangeFilterCriteria?> _filterCriteria;

		public MacroNutrientsFilter(IDictionary<MacroNutrient, RangeFilterCriteria?> filterCriteria)
		{
			_filterCriteria = filterCriteria;
		}

		public bool Satisfy(RecipeSearchInfo toFilter)
		{
			return !_filterCriteria.Any() || toFilter.MacroNutrientQuantity.All(x => IsSatisfy(x.Value, x.Key));
		}

		private bool IsSatisfy(double quantity, MacroNutrient filtered)
		{
			var filter = _filterCriteria[filtered];
			return !filter.HasValue
			       || quantity <= filter.Value.UpperLimit
			       && quantity >= filter.Value.LowerLimit;
		}
	}
}