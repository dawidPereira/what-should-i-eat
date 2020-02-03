using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Factories;
using Domain.Recipes.Services;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Recipes.Commands.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Commands
{
	[TestFixture]
	public class CreateRecipeCommandTests
	{
		private Mock<IRecipeIngredientFactory> _recipeIngredientFactoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private Mock<IIngredientRepository> _ingredientRepository;
		private Mock<IRecipeFactory> _recipeFactoryMock;
		private Mock<IImageUploader> _imageUploaderMock;
		private ICollection<ICommandValidator<CreateRecipeCommand>> _commandValidators;
		private CreateRecipeCommand _command;
		private CommandsFactory _commandsFactory;
		private CreateRecipeCommandHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepository = new Mock<IIngredientRepository>();
			_recipeFactoryMock = new Mock<IRecipeFactory>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_recipeFactoryMock = new Mock<IRecipeFactory>();
			_imageUploaderMock = new Mock<IImageUploader>();
			var commandValidator = new Mock<ICommandValidator<CreateRecipeCommand>>();
			commandValidator.Setup(x => x.Validate(It.IsAny<CreateRecipeCommand>()))
				.Returns(Result.Ok);
			_commandValidators = new List<ICommandValidator<CreateRecipeCommand>>
			{
				commandValidator.Object
			};
			_ingredientRepository.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_commandsFactory = new CommandsFactory(_ingredientRepository.Object);
			_command = _commandsFactory.CreateRecipeCommand("name", "description");
			_systemUnderTests = new CreateRecipeCommandHandler(
				_commandValidators,
				_eventPublisherMock.Object,
				_recipeFactoryMock.Object,
				_recipeIngredientFactoryMock.Object,
				_imageUploaderMock.Object);
		}

		[Test]
		public void GivenCommand_WhenNotValid_ReturnFailResult()
		{
			 _systemUnderTests.Handle(_command);
			 _eventPublisherMock.Verify(x => x.Rise(), Times.Once);
		}
	}
}