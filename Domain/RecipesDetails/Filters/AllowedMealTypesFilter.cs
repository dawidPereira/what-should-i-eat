using Domain.Common.Filters;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.SearchInfos;
using RecipeDetails = Domain.RecipesDetails.Entities.RecipeDetails;

namespace Domain.RecipesDetails.Filters
{
	public class AllowedMealTypesFilter : IFilter<RecipeDetails>
	{
		private readonly MealType? _filterCriteria;

		public AllowedMealTypesFilter(MealType? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) => 
			!_filterCriteria.HasValue || toFilter.MealTypes == _filterCriteria;
	}
}