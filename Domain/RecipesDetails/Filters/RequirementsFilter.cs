using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.RecipesDetails.Filters
{
	public class RequirementsFilter : IFilter<RecipeDetails>
	{
		private readonly Requirement? _filterCriteria;

		public RequirementsFilter(Requirement? filterCriteria) => _filterCriteria = filterCriteria;

		public bool Satisfy(RecipeDetails toFilter) => 
			!_filterCriteria.HasValue || toFilter.Requirements == _filterCriteria;
	}
}