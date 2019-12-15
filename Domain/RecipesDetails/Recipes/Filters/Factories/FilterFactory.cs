using System.Collections.Generic;
using Domain.Common.Filters;
using Domain.RecipesDetails.Recipes.Filters.FiltersCriteria;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Filters.Factories
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