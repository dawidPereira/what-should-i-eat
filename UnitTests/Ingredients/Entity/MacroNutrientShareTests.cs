using System;
using Domain.Ingredients.Entities.MacroNutrients;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	public class MacroNutrientShareTests
	{
		[Test]
		public void GivenShareLowerThanZero_DuringShareCreating_ShouldThrowArgumentException()
		{
			Action action = () => new MacroNutrientShare(MacroNutrient.Carbohydrate, -200);
			action.Should().Throw<ArgumentException>();
		}
		
		[Test]
		public void GivenShareLowerBiggerThanOneHundred_DuringShareCreating_ShouldThrowArgumentException()
		{
			Action action = () => new MacroNutrientShare(MacroNutrient.Carbohydrate, 200);
			action.Should().Throw<ArgumentException>();
		}
		
		[Test]
		public void GivenValidShare_DuringShareCreating_ShouldCreateMacroNutrientShare()
		{
			var systemUnderTest =  new MacroNutrientShare(MacroNutrient.Carbohydrate, 0.2);
			using (new AssertionScope())
			{
				systemUnderTest.Share.Should().Be(0.2);
				systemUnderTest.MacroNutrient.Should().Be(MacroNutrient.Carbohydrate);
			}
		}
	}
}