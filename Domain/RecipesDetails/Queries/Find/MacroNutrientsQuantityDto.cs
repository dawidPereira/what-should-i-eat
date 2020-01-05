namespace Domain.RecipesDetails.Queries.Find
{
	public class MacroNutrientsQuantityDto
	{
		public MacroNutrientsQuantityDto(int macroNutrient, double lowerLimit, double upperLimit)
		{
			MacroNutrient = macroNutrient;
			LowerLimit = lowerLimit;
			UpperLimit = upperLimit;
		}	
		
		public int MacroNutrient { get; }
		public double LowerLimit { get; }
		public double UpperLimit { get; }
	}
}