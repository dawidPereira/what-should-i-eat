using Domain.Common.Filters;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.RecipesDetails.Filters
{
	public class CaloriesFilter : IFilter<RecipeSearchInfo>
	{
		private readonly RangeFilterCriteria? _filterCriteria;

		public CaloriesFilter(RangeFilterCriteria? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeSearchInfo toFilter) =>
			!_filterCriteria.HasValue ||
			toFilter.Calories <= _filterCriteria.Value.UpperLimit
			&& toFilter.Calories >= _filterCriteria.Value.LowerLimit;
	}
}