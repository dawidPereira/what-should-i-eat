﻿using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.Recipes.Filters.FiltersCriteria;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Filters.Factories
{
	public interface IFilterFactory
	{
		ICollection<IFilter<RecipeSearchInfo>> BuildRecipeSearchFilters(RecipeSearchFilterCriteria? filterCriteria);
	}
}