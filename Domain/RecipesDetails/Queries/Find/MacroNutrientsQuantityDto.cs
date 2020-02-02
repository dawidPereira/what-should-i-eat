namespace Domain.RecipesDetails.Queries.Find
{
	public class MacroNutrientsQuantityDto
	{
		public MacroNutrientsQuantityDto(string macroNutrient, double? lowerLimit, double? upperLimit)
		{
			MacroNutrient = macroNutrient;
			LowerLimit = lowerLimit;
			UpperLimit = upperLimit;
		}	
		
		public string MacroNutrient { get; }
		public double? LowerLimit { get; }
		public double? UpperLimit { get; }
	}
}