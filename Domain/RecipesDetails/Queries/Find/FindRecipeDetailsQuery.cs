using System.Collections.Generic;
using Domain.Common.Mediators.Queries;

namespace Domain.RecipesDetails.Queries.Find
{
	public class FindRecipeDetailsQuery : IQuery<IEnumerable<RecipeDetailsDto>>
	{
		public FindRecipeDetailsQuery(int? requirements,
			int? notAllowedAllergens,
			int? allowedMealTypes,
			double? caloriesLowerLimit,
			double? caloriesUpperLimit,
			IEnumerable<MacroNutrientsQuantityDto> macroNutrientsQuantity)
		{
			Requirements = requirements;
			NotAllowedAllergens = notAllowedAllergens;
			AllowedMealTypes = allowedMealTypes;
			CaloriesLowerLimit = caloriesLowerLimit;
			CaloriesUpperLimit = caloriesUpperLimit;
			MacroNutrientsQuantity = macroNutrientsQuantity;
		}		
		
		public int? Requirements { get; }
		public int? NotAllowedAllergens { get; }
		public int? AllowedMealTypes { get; }
		public double? CaloriesLowerLimit { get; }
		public double? CaloriesUpperLimit { get; }
		public IEnumerable<MacroNutrientsQuantityDto> MacroNutrientsQuantity { get; }
	}
}