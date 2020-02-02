using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Filters;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.Queries.Find;

namespace Domain.RecipesDetails.Filters.FiltersCriteria
{
	public struct RecipeSearchFilterCriteria : IFilterCriteria
	{
		public RecipeSearchFilterCriteria(FindRecipeDetailsQuery query, double deviation)
		{
			Requirements = query.Requirements?.ToRequirements() ?? Requirement.None;
			NotAllowedAllergens = query.NotAllowedAllergens?.ToAllergens() ?? Allergen.None;
			AllowedMealTypes = query.AllowedMealTypes?.ToMealType() ?? MealType.None;
			CaloriesRange = GetCaloriesRange(deviation, query.CaloriesLowerLimit, query.CaloriesUpperLimit);
			MacroNutrientsQuantity = GetMacroNutrientQuantity(query.MacroNutrientsQuantity, deviation);
		}
		
		public Requirement Requirements { get; }
		public Allergen NotAllowedAllergens { get; }
		public MealType AllowedMealTypes { get; }
		public RangeFilterCriteria? CaloriesRange { get; }
		public IDictionary<MacroNutrient, RangeFilterCriteria> MacroNutrientsQuantity { get; }

		private static RangeFilterCriteria? GetCaloriesRange(double? deviation, double? lowerLimit, double? upperLimit)
		{
			if (!lowerLimit.HasValue && !upperLimit.HasValue)
				return null;
			
			return new RangeFilterCriteria(deviation, lowerLimit, upperLimit);
		}
		
		private static IDictionary<MacroNutrient, RangeFilterCriteria> GetMacroNutrientQuantity(IEnumerable<MacroNutrientsQuantityDto> dto, double? deviation)
		{
			var macroNutrientsQuantityList = dto.ToList();
			if (!macroNutrientsQuantityList.Any())
				return null;
			
			return macroNutrientsQuantityList.Select(x => MacroNutrientQuantity(x, deviation))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		private static KeyValuePair<MacroNutrient, RangeFilterCriteria> MacroNutrientQuantity (MacroNutrientsQuantityDto dto, double? deviation) =>
			new KeyValuePair<MacroNutrient, RangeFilterCriteria>(dto.MacroNutrient.ToMacroNutrient(),
				new RangeFilterCriteria(deviation, dto.LowerLimit, dto.UpperLimit));
		
	}
}