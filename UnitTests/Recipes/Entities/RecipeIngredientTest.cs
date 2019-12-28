using System;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Entities
{
	[TestFixture]
	internal class RecipeIngredientTest
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;
		
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenNegativeGrams_WhenCreatingRecipeIngredient_ThrowArgumentException()
		{
			Action action = () => _recipeIngredientFactory.Create(Guid.NewGuid(), -200);
			action.Should().Throw<ArgumentException>();
		}
		
		[Test]
		public void GivenNotExistedIngredientId_WhenCreatingRecipeIngredient_ThrowArgumentException()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(false);
			Action action = () => _recipeIngredientFactory.Create(Guid.NewGuid(), 200);
			action.Should().Throw<ArgumentException>();
		}
	}
}