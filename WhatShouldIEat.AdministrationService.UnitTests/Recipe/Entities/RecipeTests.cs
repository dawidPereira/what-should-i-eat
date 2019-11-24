using FluentAssertions;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Recipe.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipe.Entities
{
	using  Recipe = Administration.Domain.Recipes.Entities.Recipe;

	[TestFixture]
	public class RecipeTests
	{
		private Recipe _systemUnderTest;

		[SetUp]
		public void SetUp()
		{
			_systemUnderTest = RecipeFactory.Create();
		}

		[Test]
		public void GivenRecipe_WhenValid_ReturnProverValue()
		{
			var result = _systemUnderTest.CalculateCalories();
			result.Should().Be(80);
		}
	}
}