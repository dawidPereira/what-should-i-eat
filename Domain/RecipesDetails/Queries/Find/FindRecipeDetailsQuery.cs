using System.Collections.Generic;
using Domain.Common.Mediators.Queries;

namespace Domain.RecipesDetails.Queries.Find
{
	public class FindRecipeDetailsQuery : IQuery<IEnumerable<RecipeDetailsDto>>
	{
		public FindRecipeDetailsQuery(string requirements,
			string notAllowedAllergens,
			string allowedMealTypes,
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
		
		public string Requirements { get; }
		public string NotAllowedAllergens { get; }
		public string AllowedMealTypes { get; }
		public double? CaloriesLowerLimit { get; }
		public double? CaloriesUpperLimit { get; }
		public IEnumerable<MacroNutrientsQuantityDto> MacroNutrientsQuantity { get; }
	}
}