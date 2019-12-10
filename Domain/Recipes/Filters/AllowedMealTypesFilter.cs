using Domain.Common.Filters;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Filters
{
	public class AllowedMealTypesFilter : IFilter<RecipeSearchInfo>
	{
		private readonly MealType? _filterCriteria;

		public AllowedMealTypesFilter(MealType? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Test(RecipeSearchInfo toFilter) =>
			!_filterCriteria.HasValue || toFilter.MealTypes == _filterCriteria;
	}
}