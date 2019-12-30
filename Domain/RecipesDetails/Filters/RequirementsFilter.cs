using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Filters
{
	public class RequirementsFilter : IFilter<RecipeDetails>
	{
		private readonly int? _filterCriteria;

		public RequirementsFilter(int? filterCriteria) => _filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) => 
			!_filterCriteria.HasValue || toFilter.Requirements == _filterCriteria;
	}
}