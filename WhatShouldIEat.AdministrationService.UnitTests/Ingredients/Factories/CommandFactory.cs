using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
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
				MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>(),
				Allergens = new HashSet<Allergen>(),
				Requirements = new HashSet<Requirements>()
			};
		}

		internal static CreateIngredientCommand CreateValidIngredientFactory(string name)
		{
			var macroNutrients = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, 0.2)
			};

			var allergens = new HashSet<Allergen>
			{
				Allergen.Gluten,
				Allergen.Milk,
			};

			var requirements = new HashSet<Requirements>
			{
				Requirements.Ecological,
				Requirements.ForVegan
			};

			return new CreateIngredientCommand
			{
				Id = Guid.NewGuid(),
				Name = name,
				MacroNutrients = macroNutrients,
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
				MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>(),
				Allergens = new HashSet<Allergen>(),
				Requirements = new HashSet<Requirements>()
			};
		}
	}
}