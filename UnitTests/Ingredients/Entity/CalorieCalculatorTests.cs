using Domain.RecipesDetails.Ingredients.Entities.MacroNutrients;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	public class CalorieCalculatorTests
	{
		[Test]
		public void CalorieCalculator_WhenCalled_ShouldReturnProperValue()
		{
			var fatResult = MacroNutrient.Fat.CalculateCalories(100);
			var proteinResult = MacroNutrient.Protein.CalculateCalories(100);
			var carbohydrateResult = MacroNutrient.Carbohydrate.CalculateCalories(100);

			using (new AssertionScope())
			{
				fatResult.Should().Be(900);
				proteinResult.Should().Be(400);
				carbohydrateResult.Should().Be(400);
			}
		}
		
		[Test]
		public void CalorieCalculator_WhenZeroGrams_ShouldReturnZero()
		{
			var fatResult = MacroNutrient.Fat.CalculateCalories(0);
			var proteinResult = MacroNutrient.Protein.CalculateCalories(0);
			var carbohydrateResult = MacroNutrient.Carbohydrate.CalculateCalories(0);

			using (new AssertionScope())
			{
				fatResult.Should().Be(0);
				proteinResult.Should().Be(0);
				carbohydrateResult.Should().Be(0);
			}
		}
	}
}