using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Recipe.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipe.Entities
{
	[TestFixture]
	public class RecipeTests
	{
		private Domain.RecipesDetails.Recipes.Entities.Recipe _systemUnderTest;

		[SetUp]
		public void SetUp()
		{
			_systemUnderTest = RecipeFactory.Create();
		}
	}
}