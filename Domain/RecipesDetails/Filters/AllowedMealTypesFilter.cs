using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Filters
{
	public class AllowedMealTypesFilter : IFilter<RecipeDetails>
	{
		private readonly int? _filterCriteria;

		public AllowedMealTypesFilter(int? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) => 
			!_filterCriteria.HasValue || toFilter.MealTypes == _filterCriteria;
	}
}