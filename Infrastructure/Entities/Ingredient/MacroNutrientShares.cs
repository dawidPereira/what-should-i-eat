using System;

namespace Infrastructure.Entities.Ingredient
{
	public class MacroNutrientShares
	{
		public Guid IngredientId { get; set; }
		public int MacroNutrient { get; set; }
		public double Share { get; set; }
	}
}