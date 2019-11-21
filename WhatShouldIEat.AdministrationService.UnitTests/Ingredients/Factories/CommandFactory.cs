using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class  CommandFactory
	{
		internal static CreateIngredientCommand EmptyCreateIngredientCommand()
		{
			return new CreateIngredientCommand
			{
				Name = "Ingredient",
				MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>(),
				Allergens = new HashSet<Allergen>(),
				Requirements = new HashSet<Requirements>()
			};
		}
		
		internal static UpdateIngredientCommand EmptyUpdateIngredientCommand()
		{
			return new UpdateIngredientCommand
			{
				Id = new Id<Ingredient>(Guid.NewGuid()),
				Name = "Ingredient",
				MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>(),
				Allergens = new HashSet<Allergen>(),
				Requirements = new HashSet<Requirements>()
			};
		}
	}
}