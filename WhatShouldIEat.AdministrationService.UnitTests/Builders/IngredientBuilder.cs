using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Builders
{
	public class IngredientBuilder
	{
		private readonly Ingredient _ingredient;

		public IngredientBuilder()
		{
			_ingredient = new Ingredient("", new HashSet<Tuple<MacroNutrient, double>>(), new HashSet<Allergen>(), new HashSet<Requirements>());
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

		public Ingredient Build() => _ingredient;
	}
}