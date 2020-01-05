using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Queries;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Queries.Find
{
	public class FindRecipeDetailsQueryHandler : IQueryHandler<FindRecipeDetailsQuery, IEnumerable<RecipeDetailsDto>>
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;
		private const double Deviation = 0.1;

		public FindRecipeDetailsQueryHandler(IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public IEnumerable<RecipeDetailsDto> Handle(FindRecipeDetailsQuery query)
		{
			var filterCriteria = GetFilterCriteriaFromQuery(query);
			var recipes = _recipeDetailsRepository.FindRecipesDetails(filterCriteria);
			return recipes.Select(RecipeDetailsDto.FromRecipeDetails)
				.ToList();
		}

		private static RecipeSearchFilterCriteria GetFilterCriteriaFromQuery(FindRecipeDetailsQuery query)
		{
			var macroNutrientQuantity = GetMacroNutrientQuantity(query.MacroNutrientsQuantity);
			var caloriesRange = GetCaloriesRange(query.CaloriesLowerLimit, query.CaloriesUpperLimit);
			
			return new RecipeSearchFilterCriteria(
				query.Requirements,
				query.NotAllowedAllergens,
				query.AllowedMealTypes,
				caloriesRange,
				macroNutrientQuantity);
		}

		private static IDictionary<int, RangeFilterCriteria> GetMacroNutrientQuantity(IEnumerable<MacroNutrientsQuantityDto> dto) =>
			dto.Select(MacroNutrientQuantity)
				.ToDictionary(x => x.Key, x => x.Value);

		private static RangeFilterCriteria? GetCaloriesRange(double? lowerLimit, double? upperLimit)
		{
			if (!lowerLimit.HasValue && !upperLimit.HasValue)
				return null;
			
			return new RangeFilterCriteria(Deviation, lowerLimit, upperLimit);
		}

		private static KeyValuePair<int, RangeFilterCriteria> MacroNutrientQuantity (MacroNutrientsQuantityDto dto) =>
			new KeyValuePair<int, RangeFilterCriteria>(dto.MacroNutrient,
				new RangeFilterCriteria(Deviation, dto.LowerLimit, dto.UpperLimit));
	}
}