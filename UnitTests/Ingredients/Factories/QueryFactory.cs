﻿using System;
using System.Collections.Generic;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class QueryFactory
	{
		public static GetAggregatedIngredientsDetailsQuery GetDetailsFromIngredientsQuery(List<Guid> ids)
		{
			var ingredientsGrams = IngredientsGramsCollectionFactory.GetBaseIngredientsGramsDictionary(ids);
			return new GetAggregatedIngredientsDetailsQuery(ingredientsGrams);
		}
	}
}