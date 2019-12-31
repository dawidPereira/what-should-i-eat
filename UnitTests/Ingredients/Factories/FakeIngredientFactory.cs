using System;
using System.Collections.Generic;
using Domain.Events;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Repositories;
using Moq;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	internal static class FakeIngredientFactory
	{
		private const Allergen Allergens = Allergen.Gluten | Allergen.Milk;
		private const Requirement Requirements = Requirement.Ecological | Requirement.ForVegan;
		private static readonly Mock<IEventPublisher> EventPublisherMock = new Mock<IEventPublisher>();
		internal static Ingredient CreateIngredientWithOneShare(string name, MacroNutrient macroNutrient, IIngredientRepository ingredientRepository)
		{
			var ingredientFactory = new Ingredient.IngredientFactory(ingredientRepository, EventPublisherMock.Object);
			var shares = new HashSet<MacroNutrientShare>{new MacroNutrientShare(macroNutrient, 0.2)};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return ingredientFactory.Create(Guid.NewGuid(),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares);
		}
		
		internal static Ingredient CreateValidIngredient(string name, IIngredientRepository ingredientRepository)
		{
			var ingredientFactory = new Ingredient.IngredientFactory(ingredientRepository, EventPublisherMock.Object);
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2),
				new MacroNutrientShare(MacroNutrient.Fat, 0.2),
				new MacroNutrientShare(MacroNutrient.Protein, 0.3)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return ingredientFactory.Create(Guid.NewGuid(),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares);
		}
		
		internal static Ingredient CreateValidIngredientWithEventPublisher(string name, IIngredientRepository ingredientRepository, IEventPublisher eventPublisher)
		{
			var ingredientFactory = new Ingredient.IngredientFactory(ingredientRepository, eventPublisher);
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2),
				new MacroNutrientShare(MacroNutrient.Fat, 0.2),
				new MacroNutrientShare(MacroNutrient.Protein, 0.3)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return ingredientFactory.Create(Guid.NewGuid(),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares);
		}

		internal static Ingredient CreateValidIngredient(Guid id,
			string name,
			double carbohydrates,
			double fat,
			double protein,
			IIngredientRepository ingredientRepository)
		{
			var ingredientFactory = new Ingredient.IngredientFactory(ingredientRepository, EventPublisherMock.Object);
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, carbohydrates),
				new MacroNutrientShare(MacroNutrient.Fat, fat),
				new MacroNutrientShare(MacroNutrient.Protein, protein)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return ingredientFactory.Create(id, name, Allergens, Requirements, macroNutrientsShares);
		}

		internal static ICollection<Ingredient> CreateIngredientsCollection(
			List<Guid> ids, 
			IIngredientRepository ingredientRepository)
		{
			return new List<Ingredient>
			{
				CreateValidIngredient(ids[0], "First",  0.2, 0.3, 0.4, ingredientRepository),
				CreateValidIngredient(ids[1], "Second",  0.2, 0.3, 0.4, ingredientRepository),
				CreateValidIngredient(ids[2], "Third",  0.2, 0.3, 0.4, ingredientRepository)
			};
		}
	}
}