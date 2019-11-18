using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.AdministrationService.Tests
{
	[TestFixture]
	public class IngredientTests
	{
		private Ingredient _systemUnderTest;
		
		[SetUp]
		public void SetUp()
		{
			var ingredient = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Protein, 0.3d),
				new Tuple<MacroNutrient, double>(MacroNutrient.Fat, 0.4d),
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, 0.3d)
			};
			_systemUnderTest = new Ingredient("Ingredient", new HashSet<Allergen>(), new HashSet<Requirements>(), ingredient );
		}

		[Test]
		public void CalculateCaloriesPerGram_WhenCalled_ShouldReturnProperValue()
		{
			var result = _systemUnderTest.CalculateCalories(100);
			result.Should().Be(600);
		}

		[Test]
		public void CalculateCaloriesPerGram_WhenNoMacroNutrient_ShouldReturnZero()
		{
			_systemUnderTest.SetMacroNutrients(new HashSet<Tuple<MacroNutrient, double>>());
			var result = _systemUnderTest.CalculateCalories(100);
			result.Should().Be(0);
		}

		[Test]
		public void SetIngredient_WhenQuantityLowerThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			var macroNutrients = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, -22)
			};
			Action action = () => _systemUnderTest.SetMacroNutrients(macroNutrients);
			action.Should().Throw<ArgumentOutOfRangeException>();
		}
		
		[Test]
		public void SetIngredient_WhenProperValue_ShouldSetValue()
		{
			var macroNutrient = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, 1221123)
			};
			_systemUnderTest.SetMacroNutrients(macroNutrient);
			_systemUnderTest.MacroNutrientsPerGram.Should().BeEquivalentTo(macroNutrient);
		}
	}
}