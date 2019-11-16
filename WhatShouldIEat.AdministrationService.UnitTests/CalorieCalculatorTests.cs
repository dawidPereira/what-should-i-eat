using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrient;

namespace WhatShouldIEat.AdministrationService.Tests
{
	[TestFixture]
	public class CalorieCalculatorTests
	{
		[Test]
		public void CalorieCalculator_WhenCalled_ReturnProperValue()
		{
			var fatResult = MacroNutrient.Fat.CountCalorie(100);
			var proteinResult = MacroNutrient.Protein.CountCalorie(100);
			var carbohydrateResult = MacroNutrient.Carbohydrate.CountCalorie(100);

			using (new AssertionScope())
			{
				fatResult.Should().Be(900);
				proteinResult.Should().Be(400);
				carbohydrateResult.Should().Be(400);
			}
		}
	}
}