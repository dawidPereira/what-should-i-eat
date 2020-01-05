using System.Collections.Generic;
using System.Linq;
using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Filters
{
	public class MacroNutrientsFilter : IFilter<RecipeDetails>
	{
		private readonly IDictionary<int, RangeFilterCriteria> _filterCriteria;

		public MacroNutrientsFilter(IDictionary<int, RangeFilterCriteria> filterCriteria)
		{
			_filterCriteria = filterCriteria;
		}

		public bool Satisfy(RecipeDetails toFilter) => 
			!_filterCriteria.Any() || toFilter.MacroNutrientQuantity.All(x => IsSatisfy(x.Value, x.Key));

		private bool IsSatisfy(double quantity, int filtered)
		{
			if (!_filterCriteria.ContainsKey(filtered))
				return true;
			var filter = _filterCriteria[filtered];
			return quantity <= filter.UpperLimit
			       && quantity >= filter.LowerLimit;
		}
	}
}