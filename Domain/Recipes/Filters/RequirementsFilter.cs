using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Filters
{
	public class RequirementsFilter : IFilter<RecipeSearchInfo>
	{
		private readonly Requirement? _filterCriteria;

		public RequirementsFilter(Requirement? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Test(RecipeSearchInfo toFilter) =>
			!_filterCriteria.HasValue || toFilter.Requirements == _filterCriteria;
	}
}