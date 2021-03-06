﻿using System;
using System.Threading.Tasks;
using Domain.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Events.Created;
using Domain.Recipes.Events.Deleted;
using Domain.Recipes.Events.Updated;
using Domain.Recipes.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Recipes.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Entities
{
	[TestFixture]
	public class RecipeTests
	{
		private Mock<IRecipeRepository> _recipeRepositoryMock;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private FakeRecipeFactory _recipeFactory;
		private FakeRecipeIngredientsFactory _recipeIngredientsFactory;
		private Recipe _systemUnderTest;

		[SetUp]
		public async Task SetUp()
		{
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_eventPublisherMock = new Mock<IEventPublisher>();
			_recipeIngredientsFactory = new FakeRecipeIngredientsFactory(_ingredientRepositoryMock.Object);
			_recipeFactory = new FakeRecipeFactory(_recipeRepositoryMock.Object, _eventPublisherMock.Object, _ingredientRepositoryMock.Object);
			_systemUnderTest = await _recipeFactory.CreateValidRecipe("name", "description", _eventPublisherMock.Object);
		}

		[Test]
		public void UpdatedRecipe_WhenValid_ShouldPublishRecipeUpdatedEvent()
		{
			_systemUnderTest.Update("",
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_recipeIngredientsFactory.CreateValidRecipeIngredientList());

			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeUpdatedEventMessage>()), Times.Once);
		}

		[Test]
		public void DeleteRecipe_WhenNoErrors_ShouldPublishRecipeDeletedEvent()
		{
			_systemUnderTest.Delete();
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeDeletedEventMessage>()), Times.Once);
		}

		[Test]
		public void CreateRecipe_WhenValid_ShouldPublishRecipeCreatedEvent()
		{
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeCreatedEventMessage>()), Times.Once);
		}

		[Test]
		public void GivenEmptyName_WhenCreatingRecipe_ShouldThrowArgumentNullException()
		{
			Action action = () => _recipeFactory.CreateValidRecipe(null, "");
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenEmptyDescription_WhenCreatingRecipe_ShouldThrowArgumentNullException()
		{
			Action action = () => _recipeFactory.CreateValidRecipe("", null);
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenEmptyName_WhenUpdatingRecipe_ShouldThrowArgumentNullException()
		{
			Action action = () => _systemUnderTest.Update(null,
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_recipeIngredientsFactory.CreateValidRecipeIngredientList());
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenEmptyDescription_WhenUpdatingRecipe_ShouldThrowArgumentNullException()
		{
			Action action = () => _systemUnderTest.Update("",
				null,
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_recipeIngredientsFactory.CreateValidRecipeIngredientList());
			action.Should().Throw<ArgumentNullException>();
		}

	}
}
