using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class QueryFactory
	{
		public static GetDetailsFromIngredientsQuery GetDetailsFromIngredientsQuery(List<Identity<Guid>> ids)
		{
			var ingredientsGrams = IngredientsGramsCollectionFactory.GetBaseIngredientsGramsDictionary(ids);
			return new GetDetailsFromIngredientsQuery(ingredientsGrams);
		}
	}
}