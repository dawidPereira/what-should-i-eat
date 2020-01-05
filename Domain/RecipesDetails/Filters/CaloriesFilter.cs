using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Filters
{
	public class CaloriesFilter : IFilter<RecipeDetails>
	{
		private readonly RangeFilterCriteria? _filterCriteria;

		public CaloriesFilter(RangeFilterCriteria? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter)
		{
			if (!_filterCriteria.HasValue)
				return true;

			return _filterCriteria.Value.LowerLimit.HasValue && _filterCriteria.Value.UpperLimit.HasValue
				? toFilter.Calories <= _filterCriteria.Value.UpperLimit && toFilter.Calories >= _filterCriteria.Value.LowerLimit
				: _filterCriteria.Value.LowerLimit.HasValue ? toFilter.Calories >= _filterCriteria.Value.LowerLimit
				: !_filterCriteria.Value.UpperLimit.HasValue || toFilter.Calories <= _filterCriteria.Value.UpperLimit;
		}
	}
}