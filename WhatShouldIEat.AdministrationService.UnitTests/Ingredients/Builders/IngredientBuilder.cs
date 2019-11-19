using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders
{
	internal class IngredientBuilder
	{
		private readonly Ingredient _ingredient;

		public IngredientBuilder()
		{
			_ingredient = new Ingredient("",
				new HashSet<Allergen>(),
				new HashSet<Requirements>(),
				new HashSet<Tuple<MacroNutrient, double>>());
		}

		public IngredientBuilder WithMacroNutrient()
		{
			var macroNutrients = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, 0.2)
			};

			_ingredient.SetMacroNutrients(macroNutrients);
			return this;
		}

		public IngredientBuilder WithName(string name)
		{
			_ingredient.Name = name;
			return this;
		}

		public Ingredient Build() => _ingredient;
	}
}