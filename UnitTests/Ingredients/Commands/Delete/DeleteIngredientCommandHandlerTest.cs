﻿using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Commands.Delete;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Factories;
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
		private Mock<IRecipeRepository> _recipeRepositoryMock;
		private Mock<IEventPublisher> _eventPublisher;
		private IEnumerable<ICommandValidator<DeleteIngredientCommand>> _validators;
		private DeleteIngredientCommand _command;
		private DeleteIngredientCommandHandler _systemUnderTest;
		private IIngredientFactory _ingredientFactory;
		private Ingredient _ingredient;
		
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_eventPublisher = new Mock<IEventPublisher>();
			_command = new DeleteIngredientCommand(new Identity<Guid>(Guid.NewGuid()));
			_ingredient = FakeIngredientFactory.CreateValidIngredient(
				new Identity<Guid>(Guid.NewGuid()),
				"Ingredient",
				0.2,
				0.3,
				0.4,
				_ingredientRepositoryMock.Object);
			_validators = new List<ICommandValidator<DeleteIngredientCommand>>
			{
				new NotUsedIngredientValidator(_recipeRepositoryMock.Object)
			};

			_systemUnderTest = new DeleteIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators);
		}


		[Test]
		public void GivenIngredientId_WhenIngredientNotExist_ShouldReturnFailure()
		{
			var result  = _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
		}
		
		[Test]
		public void GivenIngredientId_WhenIngredientExist_ShouldReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Identity<Guid>>()))
				.Returns(_ingredient);

			var result  = _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}

		[Test][Ignore("To be decided if this rule will be exist")]
		public void GivenIngredientId_WhenIngredientIsUsedInRecipe_ShouldReturnFailure()
		{
			var recipeBasicInfos = new List<RecipeBasicInfo>
			{
				new RecipeBasicInfo(Guid.NewGuid(),"ExistName")
			};
			
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Identity<Guid>>()))
				.Returns(_ingredient);
			_recipeRepositoryMock.Setup(x => x.GetRecipesBasicInfosByIngredientId(It.IsAny<Identity<Guid>>()))
				.Returns(recipeBasicInfos);

			var result = _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
			result.Message.Should()
				.Contain("Ingredient cannot be deleted. Ingredient is used in following recipes:");
		}
	}
}