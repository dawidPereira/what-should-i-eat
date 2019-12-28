using System;
using Domain.Ingredients.Entities.MacroNutrients;

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
		
		public static MacroNutrientShares FromDomainIngredient(Guid id, MacroNutrientShare macroNutrientShare)
			=> new MacroNutrientShares(id, (int)macroNutrientShare.MacroNutrient, macroNutrientShare.Share);
	}
}