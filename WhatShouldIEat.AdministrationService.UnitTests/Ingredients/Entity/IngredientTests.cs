using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	internal class IngredientTests
	{
		private const string IngredientName = "IngredientName";
		private Ingredient _ingredient;
		
		[SetUp]
		public void SetUp()
		{
			_ingredient = new IngredientBuilder()
				.WithName(IngredientName)
				.WithMacroNutrient()
				.WithAllergens()
				.WithRequirements()
				.Build();
		}

		[Test]
		public void GivenProperIngredient_WhenToDtoCalled_MapIngredientToDto()
		{
			var result = _ingredient.ToDto();
			using (new AssertionScope())
			{
				result.Id.Should().Be(_ingredient.Id);
				result.Name.Should().Be(_ingredient.Name);
				result.Allergens.Should().BeEquivalentTo(_ingredient.Allergens);
				result.Requirements.Should().BeEquivalentTo(_ingredient.Requirements);
				result.MacroNutrientsPerGram.Should().BeEquivalentTo(_ingredient.MacroNutrientsPerGram);
			}
		}
	}
}