using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.Recipes.SearchInfos;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Filters.Factories
{
	public interface IFilterFactory
	{
		ICollection<IFilter<RecipeSearchInfo>> BuildRecipeSearchFilters(RecipeSearchFilterCriteria? filterCriteria);
	}
}