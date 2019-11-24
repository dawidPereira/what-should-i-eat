using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	internal class IngredientTests
	{
		private const string IngredientName = "IngredientName";
		private Ingredient _systemUnderTest;
		
		[SetUp]
		public void SetUp() => 
			_systemUnderTest = Ingredient.Create(CommandFactory.CreateValidIngredientFactory(IngredientName));

		[Test]
		public void GivenProperIngredient_WhenToDtoCalled_MapIngredientToDto()
		{
			var result = _systemUnderTest.ToDto();
			using (new AssertionScope())
			{
				result.Id.Should().Be(_systemUnderTest.Id);
				result.Name.Should().Be(_systemUnderTest.Name);
				result.Allergens.Should().BeEquivalentTo(_systemUnderTest.Allergens);
				result.Requirements.Should().BeEquivalentTo(_systemUnderTest.Requirements);
				result.MacroNutrientsPerGram.Should().BeEquivalentTo(_systemUnderTest.MacroNutrientsPerGram);
			}
		}
		
		[Test]
		public void CalculateCaloriesPerGram_WhenCalled_ShouldReturnProperValue()
		{
			var result = _systemUnderTest.CalculateCalories(100);
			result.Should().Be(80);
		}
	}
}