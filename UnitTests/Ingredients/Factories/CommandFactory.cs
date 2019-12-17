using System;
using System.Collections.Generic;
using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	internal static class CommandFactory
	{
		private const Allergen Allergens = Allergen.Gluten | Allergen.Milk;
		private const Requirement Requirements = Requirement.Ecological | Requirement.ForVegan;
		
		internal static CreateIngredientCommand EmptyCreateIngredientCommand() =>
			new CreateIngredientCommand(Guid.NewGuid(), "IngredientId", Allergen.None, Requirement.None,
				new MacroNutrientsSharesCollection(new List<MacroNutrientShare>()));

		internal static UpdateIngredientCommand EmptyUpdateIngredientCommand() =>
			new UpdateIngredientCommand(Guid.NewGuid(), "IngredientId", Allergen.None, Requirement.None,
				new MacroNutrientsSharesCollection(new List<MacroNutrientShare>()));

		internal static CreateIngredientCommand ValidCreateIngredientCommand(string name)
		{
			var share = new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2);
			var macroNutrientsParticipation = new MacroNutrientsSharesCollection(new List<MacroNutrientShare>{share});
			return new CreateIngredientCommand(Guid.NewGuid(), name, Allergens, Requirements, macroNutrientsParticipation);
		}
	}
}