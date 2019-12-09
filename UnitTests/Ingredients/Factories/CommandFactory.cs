using System;
using System.Collections.Generic;
using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class CommandFactory
	{
		internal static CreateIngredientCommand EmptyCreateIngredientCommand()
		{
			return new CreateIngredientCommand
			{
				Id = Guid.NewGuid(),
				Name = "Ingredient",
				MacroNutrientsParticipation = new List<IngredientMacroNutrient>(),
				Allergens = Allergen.None,
				Requirements = Requirement.None
			};
		}

		internal static CreateIngredientCommand CreateValidIngredientFactory(string name)
		{
			var macroNutrientsParticipation = new List<IngredientMacroNutrient>();
			macroNutrientsParticipation.Add(
				new IngredientMacroNutrient(Guid.NewGuid(), MacroNutrient.Carbohydrate,  0.2));

			var allergens =  Allergen.Gluten | Allergen.Milk;
			var requirements = Requirement.Ecological | Requirement.ForVegan;

			return new CreateIngredientCommand
			{
				Id = Guid.NewGuid(),
				Name = name,
				MacroNutrientsParticipation = macroNutrientsParticipation,
				Allergens = allergens,
				Requirements = requirements
			};
		}

		internal static UpdateIngredientCommand EmptyUpdateIngredientCommand()
		{
			return new UpdateIngredientCommand
			{
				Id = Guid.NewGuid(),
				Name = "IngredientId",
				Allergens = Allergen.None,
				Requirements = Requirement.None,
				MacroNutrientsParticipation = new List<IngredientMacroNutrient>()
			};
		}
	}
}