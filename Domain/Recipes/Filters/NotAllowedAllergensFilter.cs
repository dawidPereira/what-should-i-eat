﻿using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Filters
{
	public class NotAllowedAllergensFilter : IFilter<RecipeSearchInfo>
	{
		private readonly Allergen? _filterCriteria;

		public NotAllowedAllergensFilter(Allergen? filterCriteria) => 
			_filterCriteria = filterCriteria;

		public bool Test(RecipeSearchInfo toFilter) =>
			!_filterCriteria.HasValue || toFilter.Allergens == _filterCriteria;
	}
}