using Domain.Common.Filters;
using Domain.RecipesDetails.Recipes.Entities;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters
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