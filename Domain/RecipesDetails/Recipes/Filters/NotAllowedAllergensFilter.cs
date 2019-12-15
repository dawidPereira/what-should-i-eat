using Domain.Common.Filters;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters
{
	public class NotAllowedAllergensFilter : IFilter<RecipeSearchInfo>
	{
		private readonly Allergen? _filterCriteria;

		public NotAllowedAllergensFilter(Allergen? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeSearchInfo toFilter) => 
			!_filterCriteria.HasValue || toFilter.Allergens == _filterCriteria;
	}
}