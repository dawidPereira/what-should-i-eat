using System;
using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;

namespace Domain.RecipesDetails.Ingredients.Entities
{
	public class IngredientMacroNutrient
	{
		public IngredientMacroNutrient(Guid ingredientId, MacroNutrient macroNutrient, double participationInIngredient)
		{
			Id = Guid.NewGuid();
			IngredientId = ingredientId;
			MacroNutrient = macroNutrient;
			ParticipationInIngredient = participationInIngredient;
		}

		public Guid Id { get; private set; }
		public Guid IngredientId { get; private set; }
		public MacroNutrient MacroNutrient { get; private set; }
		public double ParticipationInIngredient { get; private set; }
	}
}