using System;
using Domain.Common.Mediators.Events;
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
		public void SetUp()
		{
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_recipeIngredientsFactory = new FakeRecipeIngredientsFactory(_ingredientRepositoryMock.Object);
			_recipeFactory = new FakeRecipeFactory(_recipeRepositoryMock.Object, _eventPublisherMock.Object, _ingredientRepositoryMock.Object);
			_systemUnderTest = _recipeFactory.CreateValidRecipe("name", "description");
		}

		[Test]
		public void UpdatedRecipe_WhenValid_ShouldPublishRecipeUpdatedEvent()
		{
			_systemUnderTest.Update("",
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_recipeIngredientsFactory.CreateValidRecipeIngredientList());
			
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeUpdatedEvent>()), Times.Once);
		}

		[Test]
		public void DeleteRecipe_WhenNoErrors_ShouldPublishRecipeDeletedEvent()
		{
			_systemUnderTest.Delete();
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeDeletedEvent>()), Times.Once);
		}

		[Test]
		public void CreateRecipe_WhenValid_ShouldPublishRecipeCreatedEvent()
		{
			var recipe = _recipeFactory.CreateValidRecipe("", "");
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<RecipeCreatedEvent>()), Times.Once);
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