using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class IngredientsGramsCollectionFactory
	{
		public static IDictionary<Identity<Guid>, double> GetBaseIngredientsGramsDictionary(List<Identity<Guid>> ids) =>
			new Dictionary<Identity<Guid>, double>
			{
				{ids[0], 100},
				{ids[1], 200},
				{ids[2], 50}
			};
	}
}