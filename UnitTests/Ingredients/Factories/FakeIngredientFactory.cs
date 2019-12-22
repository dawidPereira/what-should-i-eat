using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
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

		internal static Ingredient CreateValidIngredient(Identity<Guid> id,
			string name,
			IEventPublisher eventPublisher,
			double carbohydrates,
			double fat,
			double protein)
		{
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, carbohydrates),
				new MacroNutrientShare(MacroNutrient.Fat, fat),
				new MacroNutrientShare(MacroNutrient.Protein, protein)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return new Ingredient(id, name, Allergens, Requirements, macroNutrientsShares, eventPublisher);
		}

		internal static IEnumerable<Ingredient> CreateIngredientsCollection(List<Identity<Guid>> ids, IEventPublisher eventPublisher)
		{
			return new List<Ingredient>
			{
				CreateValidIngredient(ids[0], "First", eventPublisher, 0.2, 0.3, 0.4),
				CreateValidIngredient(ids[1], "Second", eventPublisher, 0.2, 0.3, 0.4),
				CreateValidIngredient(ids[2], "Third", eventPublisher, 0.2, 0.3, 0.4)
			};
		}
	}
}