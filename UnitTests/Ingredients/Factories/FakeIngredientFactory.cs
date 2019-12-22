using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;
using Moq;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	internal static class FakeIngredientFactory
	{
		private const Allergen Allergens = Allergen.Gluten | Allergen.Milk;
		private const Requirement Requirements = Requirement.Ecological | Requirement.ForVegan;
		private static readonly Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();
		private static readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();
		private static readonly IIngredientFactory _ingredientFactory = new Ingredient.IngredientFactory(_ingredientRepositoryMock.Object);
		internal static Ingredient CreateIngredientWithOneShare(string name, MacroNutrient macroNutrient)
		{
			var shares = new HashSet<MacroNutrientShare>{new MacroNutrientShare(macroNutrient, 0.2)};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return _ingredientFactory.Create(new Identity<Guid>(Guid.NewGuid()),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares,
				_eventPublisherMock.Object);
		}
		
		internal static Ingredient CreateValidIngredient(string name)
		{
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2),
				new MacroNutrientShare(MacroNutrient.Fat, 0.2),
				new MacroNutrientShare(MacroNutrient.Protein, 0.3)
			};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return _ingredientFactory.Create(new Identity<Guid>(Guid.NewGuid()),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares,
				_eventPublisherMock.Object);
		}

		internal static Ingredient CreateIngredientWithInvalidId(string name)
		{
			var shares = new HashSet<MacroNutrientShare>{new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2)};
			var macroNutrientsShares = new MacroNutrientsSharesCollection(shares);
			return _ingredientFactory.Create(new Identity<Guid>(new Guid("")),
				name,
				Allergens,
				Requirements,
				macroNutrientsShares,
				_eventPublisherMock.Object);
		}

		internal static Ingredient CreateValidIngredient(Identity<Guid> id,
			string name,
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
			return _ingredientFactory.Create(id, name, Allergens, Requirements, macroNutrientsShares, _eventPublisherMock.Object);
		}

		internal static IEnumerable<Ingredient> CreateIngredientsCollection(List<Identity<Guid>> ids, IEventPublisher eventPublisher)
		{
			return new List<Ingredient>
			{
				CreateValidIngredient(ids[0], "First",  0.2, 0.3, 0.4),
				CreateValidIngredient(ids[1], "Second",  0.2, 0.3, 0.4),
				CreateValidIngredient(ids[2], "Third",  0.2, 0.3, 0.4)
			};
		}
	}
}