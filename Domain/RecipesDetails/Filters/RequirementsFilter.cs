using Domain.Common.Filters;
using Domain.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Filters
{
	public class RequirementsFilter : IFilter<RecipeSearchInfo>
	{
		private readonly Requirement? _filterCriteria;

		public RequirementsFilter(Requirement? filterCriteria) => _filterCriteria = filterCriteria;

		public bool Satisfy(RecipeSearchInfo toFilter) => 
			!_filterCriteria.HasValue || toFilter.Requirements == _filterCriteria;
	}
}