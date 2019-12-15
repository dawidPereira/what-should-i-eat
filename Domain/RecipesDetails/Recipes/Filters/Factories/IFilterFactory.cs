using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.RecipesDetails.Recipes.Filters.FiltersCriteria;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters.Factories
{
	public interface IFilterFactory
	{
		ICollection<IFilter<RecipeSearchInfo>> BuildRecipeSearchFilters(RecipeSearchFilterCriteria? filterCriteria);
	}
}