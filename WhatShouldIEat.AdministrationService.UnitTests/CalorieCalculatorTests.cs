using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredient.Entities;
using WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrints;

namespace WhatShouldIEat.AdministrationService.Tests
{
	[TestFixture]
	public class CalorieCalculatorTests
	{
		[Test]
		public void CalorieCalculator_WhenCalled_ReturnProperValue()
		{
			var fatResult = MacroNutrient.Fat.CountCalorieFromMass(100);
			var proteinResult = MacroNutrient.Protein.CountCalorieFromMass(100);
			var carbohydrateResult = MacroNutrient.Carbohydrate.CountCalorieFromMass(100);

			using (new AssertionScope())
			{
				fatResult.Should().Be(900);
				proteinResult.Should().Be(400);
				carbohydrateResult.Should().Be(400);
			}
		}
	}
}