using Domain.Common.Filters;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Filters
{
	public class AllowedMealTypesFilter : IFilter<RecipeDetails>
	{
		private readonly MealType _filterCriteria;

		public AllowedMealTypesFilter(MealType filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) => 
			_filterCriteria == MealType.None || toFilter.MealTypes == _filterCriteria;
	}
}