using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Filters
{
	public class NotAllowedAllergensFilter : IFilter<RecipeDetails>
	{
		private readonly int? _filterCriteria;

		public NotAllowedAllergensFilter(int? filterCriteria) =>
			_filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) =>
			!_filterCriteria.HasValue || toFilter.Allergens == _filterCriteria;
	}
}