using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

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
			var macroNutrientsParticipation = new List<IngredientMacroNutrient>()
			{
				new IngredientMacroNutrient
				{
					MacroNutrient = MacroNutrient.Carbohydrate, ParticipationInIngredient = 0.2
				}
			};

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
				Name = "Ingredient",
				Allergens = Allergen.None,
				Requirements = Requirement.None,
				MacroNutrientsParticipation = new List<IngredientMacroNutrient>()
			};
		}
	}
}