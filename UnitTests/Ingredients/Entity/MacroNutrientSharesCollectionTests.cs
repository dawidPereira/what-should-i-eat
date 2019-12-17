using System;
using System.Collections.Generic;
using Domain.Ingredients.Entities.MacroNutrients;
using FluentAssertions;
using NUnit.Framework;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	public class MacroNutrientSharesCollectionTests
	{
		[Test]
		public void GivenSharesSumBiggerThanOneHundred_DuringCreating_ShouldReturnArgumentOutOfRangeException()
		{
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.9),
				new MacroNutrientShare(MacroNutrient.Fat, 0.9)
			};
			
			Action action = () => new MacroNutrientsSharesCollection(shares);
			action.Should().Throw<ArgumentOutOfRangeException>();
		}
		
		[Test]
		public void GivenSharesSumLowerThanOneHundred_DuringCreating_ShouldCreateCollection()
		{
			var shares = new HashSet<MacroNutrientShare>
			{
				new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2),
				new MacroNutrientShare(MacroNutrient.Fat, 0.1)
			};
			
			Action action = () => new MacroNutrientsSharesCollection(shares);
			action.Should().Throw<ArgumentOutOfRangeException>();
		}
	}
}