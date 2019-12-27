using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Factories;
using Domain.Recipes.Repositories;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Recipes.Commands.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Commands
{
	[TestFixture]
	public class CreateRecipeCommandTests
	{
		private Mock<IRecipeRepository> _recipeRepositoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private Mock<IIngredientRepository> _ingredientRepository;
		private Mock<IRecipeFactory> _recipeFactoryMock;
		private ICollection<ICommandValidator<CreateRecipeCommand>> _commandValidators;
		private CreateRecipeCommand _command;
		private CommandsFactory _commandsFactory;
		private CreateRecipeCommandHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_ingredientRepository = new Mock<IIngredientRepository>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_recipeFactoryMock = new Mock<IRecipeFactory>();
			var commandValidator = new Mock<ICommandValidator<CreateRecipeCommand>>();
			commandValidator.Setup(x => x.Validate(It.IsAny<CreateRecipeCommand>()))
				.Returns(Result.Ok);
			_commandValidators = new List<ICommandValidator<CreateRecipeCommand>>
			{
				commandValidator.Object
			};
			_ingredientRepository.Setup(x => x.ExistById(It.IsAny<Identity<Guid>>()))
				.Returns(true);
			_commandsFactory = new CommandsFactory(_ingredientRepository.Object);
			_command = _commandsFactory.CreateRecipeCommand("name", "description");
			_systemUnderTests = new CreateRecipeCommandHandler(
				_recipeRepositoryMock.Object, 
				_commandValidators,
				_eventPublisherMock.Object,
				_recipeFactoryMock.Object);
		}

		[Test]
		public void GivenCommand_WhenNotValid_ReturnFailResult()
		{
			 _systemUnderTests.Handle(_command);
			 _eventPublisherMock.Verify(x => x.Rise(It.IsAny<string>()), Times.Once);
		}
	}
}