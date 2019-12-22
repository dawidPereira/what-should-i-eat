using Domain.Common.Filters;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.RecipesDetails.Filters
{
	public class AllowedMealTypesFilter : IFilter<RecipeSearchInfo>
	{
		private readonly MealType? _filterCriteria;

		public AllowedMealTypesFilter(MealType? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeSearchInfo toFilter) => 
			!_filterCriteria.HasValue || toFilter.MealTypes == _filterCriteria;
	}
}