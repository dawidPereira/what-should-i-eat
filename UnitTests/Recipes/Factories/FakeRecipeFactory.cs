using System;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;
using Moq;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal static class FakeRecipeFactory
	{
		private static Recipe.RecipeFactory _recipeFactory;
		private static Mock<IRecipeRepository> _recipeRepositoryMock;
		private static Mock<IEventPublisher> _eventPublisherMock;

		static FakeRecipeFactory()
		{
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_recipeFactory = new Recipe.RecipeFactory(_recipeRepositoryMock.Object, _eventPublisherMock.Object);
		}

		public static Recipe CreateValidRecipe() =>
			_recipeFactory.Create(Guid.NewGuid(),
				"",
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				FakeRecipeIngredientsFactory.CreateValidRecipeIngredientList(),
				_eventPublisherMock.Object,
				_recipeRepositoryMock.Object);
	}
}