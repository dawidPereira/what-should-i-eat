using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.RecipesDetails.Filters.Factories
{
	public interface IFilterFactory
	{
		ICollection<IFilter<RecipeSearchInfo>> BuildRecipeSearchFilters(RecipeSearchFilterCriteria? filterCriteria);
	}
}