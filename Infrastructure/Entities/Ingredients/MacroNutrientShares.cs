using System;
using Domain.Ingredients.Entities.MacroNutrients;

namespace Infrastructure.Entities.Ingredient
{
	public class MacroNutrientShares
	{
		private MacroNutrientShares() {}
		
		public MacroNutrientShares(Guid ingredientId, string macroNutrient, double share)
		{
			IngredientId = ingredientId;
			MacroNutrient = macroNutrient;
			Share = share;
		}
		public Guid IngredientId { get; set; }
		public string MacroNutrient { get; set; }
		public double Share { get; set; }
		
		public static MacroNutrientShares FromDomainIngredient(Guid id, MacroNutrientShare macroNutrientShare)
			=> new MacroNutrientShares(id, macroNutrientShare.MacroNutrient.ToString(), macroNutrientShare.Share);
	}
}