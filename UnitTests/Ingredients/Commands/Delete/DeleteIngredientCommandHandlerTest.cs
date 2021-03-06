﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common.Mediators.Validators;
using Domain.Events;
using Domain.Ingredients.Commands.Delete;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Queries.GetBasicInfos;
using Domain.Recipes.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands.Delete
{
	[TestFixture]
	internal class DeleteIngredientCommandHandlerTest
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private Mock<IRecipeRepository> _recipeRepositoryMock;
		private IEnumerable<ICommandValidator<DeleteIngredientCommand>> _validators;
		private DeleteIngredientCommand _command;
		private DeleteIngredientCommandHandler _systemUnderTest;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_command = new DeleteIngredientCommand(Guid.NewGuid());
			_ingredient = FakeIngredientFactory.CreateValidIngredient(
				Guid.NewGuid(),
				"Ingredient",
				0.2,
				0.3,
				0.4,
				_ingredientRepositoryMock.Object);

			_systemUnderTest = new DeleteIngredientCommandHandler(_ingredientRepositoryMock.Object, _eventPublisherMock.Object);
		}


		[Test]
		public async Task GivenIngredientId_WhenIngredientNotExist_ShouldReturnFailure()
		{
			var result  = await _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
		}

		[Test]
		public async Task GivenIngredientId_WhenIngredientExist_ShouldReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(_ingredient);

			var result  = await _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}

		[Test][Ignore("To be decided if this rule will be exist")]
		public async Task GivenIngredientId_WhenIngredientIsUsedInRecipe_ShouldReturnFailure()
		{
			var recipeBasicInfos = new List<RecipeBasicInfo>
			{
				new RecipeBasicInfo(Guid.NewGuid(),"ExistName")
			};

			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(_ingredient);
			_recipeRepositoryMock.Setup(x => x.GetRecipesBasicInfosByIngredientId(It.IsAny<Guid>()))
				.Returns(recipeBasicInfos);

			var result = await _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
			result.Message.Should()
				.Contain("Ingredient cannot be deleted. Ingredient is used in following recipes:");
		}
	}
}
