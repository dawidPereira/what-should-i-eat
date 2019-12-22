using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.SearchInfos;

namespace Domain.RecipesDetails.Filters.Factories
{
	public class FilterFactory : IFilterFactory
	{
		public ICollection<IFilter<RecipeSearchInfo>> BuildRecipeSearchFilters(RecipeSearchFilterCriteria? filterCriteria)
		{
			return new List<IFilter<RecipeSearchInfo>>
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