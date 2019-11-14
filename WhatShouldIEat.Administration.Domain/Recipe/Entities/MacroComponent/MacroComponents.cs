using System;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.MacroComponent
{
	public class MacroComponents
	{
		public MacroComponents(Id<Ingredient> ingredientId,
			MacroComponent protein,
			MacroComponent carbohydrate,
			MacroComponent fat)
		{
			Id = new Id<MacroComponents>(Guid.NewGuid());
			IngredientId = ingredientId;
			Protein = protein;
			Carbohydrate = carbohydrate;
			Fat = fat;
		}

		public Id<MacroComponents> Id { get; private set; }
		public Id<Ingredient> IngredientId { get; private set; }
		public MacroComponent Protein { get; private set; }
		public MacroComponent Carbohydrate { get; private set; }
		public MacroComponent Fat { get; private set; }
	}
}