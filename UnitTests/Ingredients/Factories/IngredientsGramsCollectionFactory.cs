using System;
using System.Collections.Generic;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	public static class IngredientsGramsCollectionFactory
	{
		public static IDictionary<Guid, double> GetBaseIngredientsGramsDictionary(List<Guid> ids) =>
			new Dictionary<Guid, double>
			{
				{ids[0], 100},
				{ids[1], 200},
				{ids[2], 50}
			};
	}
}