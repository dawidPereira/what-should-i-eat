using Domain.Common.Filters;
using Domain.RecipesDetails.Recipes.Filters.FiltersCriteria;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters
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