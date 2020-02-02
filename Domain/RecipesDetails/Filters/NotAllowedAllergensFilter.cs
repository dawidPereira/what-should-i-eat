using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Filters
{
	public class NotAllowedAllergensFilter : IFilter<RecipeDetails>
	{
		private readonly Allergen _filterCriteria;

		public NotAllowedAllergensFilter(Allergen filterCriteria) =>
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) =>
			_filterCriteria == Allergen.None || toFilter.Allergens == _filterCriteria;
	}
}