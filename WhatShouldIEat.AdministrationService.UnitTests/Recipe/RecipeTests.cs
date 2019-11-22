using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;

namespace WhatShouldIEat.AdministrationService.Tests.Recipe
{
	using Recipe = Administration.Domain.Recipe.Entities.Recipe.Recipe;
	
	[TestFixture]
	public class RecipeTests
	{
		private Recipe _systemUnderTest;
		private Ingredient _ingredient;
		private List<RecipeIngredient> _ingredients;

		[SetUp]
		public void SetUp()
		{
			_ingredient = new IngredientBuilder()
				.WithMacroNutrient()
				.Build();
			
			_ingredients = new List<RecipeIngredient>
			{
				new RecipeIngredient(Guid.NewGuid(),Guid.NewGuid(),100)
			};
			
			_systemUnderTest = new Recipe(Guid.NewGuid(), "Name", "Description", _ingredients, 
				new RecipeDetails(0, 0, 0, new List<MealType>()));
		}

		[Test]
		public void SetRecipeIngredients_WhenQuantityLowerThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			_ingredients = new List<RecipeIngredient>
			{
				new RecipeIngredient(Guid.NewGuid(),Guid.NewGuid(), -100)
			};
			
			Action action = () => _systemUnderTest.SetRecipeIngredients(new List<RecipeIngredient>(_ingredients));
			action.Should().Throw<ArgumentOutOfRangeException>();
		}

		[Test]
		public void SetIngredient_WhenProperValue_ShouldSetValue()
		{
			var ingredients = new List<RecipeIngredient>
			{
				new RecipeIngredient(Guid.NewGuid(),Guid.NewGuid(), 132121)
			};
			_systemUnderTest.SetRecipeIngredients(ingredients);
			_systemUnderTest.RecipeIngredients.Should().BeEquivalentTo(ingredients);
		}

		[Test]
		public void METHOD()
		{
			
		}
	}
}