using System;

namespace Infrastructure.Entities.Ingredient
{
	public class MacroNutrientShares
	{
		public MacroNutrientShares(Guid ingredientId, int macroNutrient, double share)
		{
			IngredientId = ingredientId;
			MacroNutrient = macroNutrient;
			Share = share;
		}
		public Guid IngredientId { get; set; }
		public int MacroNutrient { get; set; }
		public double Share { get; set; }
	}
}