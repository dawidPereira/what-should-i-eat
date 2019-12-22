using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class IngredientsGramsCollectionFactory
	{
		public static IngredientsGramsCollection GetBaseCollection(IEventPublisher eventPublisher)
		{
			var ingredientsGrams = new List<IngredientGrams>
			{
				new IngredientGrams(FakeIngredientFactory.CreateValidIngredient(
					"1", eventPublisher, 0.2, 0.3, 0.4), 100),
				new IngredientGrams(FakeIngredientFactory.CreateValidIngredient(
					"1", eventPublisher, 0.2, 0.3, 0.4), 200),
				new IngredientGrams(FakeIngredientFactory.CreateValidIngredient(
					"1", eventPublisher, 0.2, 0.3, 0.4), 50)
			};
			
			return new IngredientsGramsCollection(ingredientsGrams);
		}

		public static IDictionary<Identity<Guid>, double> GetBaseIngredientsGramsDictionary(List<Identity<Guid> ids) =>
			new Dictionary<Identity<Guid>, double>
			{
				{ids[0], 100},
				{ids[1], 200},
				{ids[2], 50}
			};
	}
}