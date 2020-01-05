using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Filters.Factories
{
	public class RecipeFiltersFactory : IFilterFactory<RecipeDetails, RecipeSearchFilterCriteria>
	{
		public IEnumerable<IFilter<RecipeDetails>> Build(RecipeSearchFilterCriteria filterCriteria)
		{
			return new List<IFilter<RecipeDetails>>
			{
				new CaloriesFilter(filterCriteria.CaloriesRange),
				new RequirementsFilter(filterCriteria.Requirements),
				new MacroNutrientsFilter(filterCriteria.MacroNutrientsQuantity),
				new AllowedMealTypesFilter(filterCriteria.AllowedMealTypes),
				new NotAllowedAllergensFilter(filterCriteria.NotAllowedAllergens)
			};
		}
	}
}