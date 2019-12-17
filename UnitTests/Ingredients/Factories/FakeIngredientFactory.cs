using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	internal static class FakeIngredientFactory
	{
		private const Allergen Allergens = Allergen.Gluten | Allergen.Milk;
		private const Requirement Requirements = Requirement.Ecological | Requirement.ForVegan;
		
		internal static Ingredient CreateIngredientWithOneShare(string name, MacroNutrient macroNutrient, IEventPublisher eventPublisher)
		{
			var shares = new HashSet<MacroNutrientShare>{new MacroNutrientShare(macroNutrient, 0.2)};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return new Ingredient(new Identity<Guid>(Guid.NewGuid()), name, Allergens, Requirements, macroNutrientsShares, eventPublisher);
		}
		
		internal static Ingredient CreateValidIngredient(string name, IEventPublisher eventPublisher)
		{
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2),
				new MacroNutrientShare(MacroNutrient.Fat, 0.2),
				new MacroNutrientShare(MacroNutrient.Protein, 0.3)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return new Ingredient(new Identity<Guid>(Guid.NewGuid()), name, Allergens, Requirements, macroNutrientsShares, eventPublisher);
		}
		
		internal static Ingredient CreateIngredientWithInvalidId(string name, IEventPublisher eventPublisher)
		{
			var shares = new HashSet<MacroNutrientShare>{new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2)};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return new Ingredient(new Identity<Guid>(new Guid("")), name, Allergens, Requirements, macroNutrientsShares, eventPublisher);
		}
	}
}