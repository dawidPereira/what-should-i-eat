using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands.Update
{
	[TestFixture]
	public class UpdateIngredientCommandHandlerTests
	{
		private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();

		private readonly Mock<ICommandValidator<UpdateIngredientCommand>> _validator =
			new Mock<ICommandValidator<UpdateIngredientCommand>>();

		private Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();
		private IEnumerable<ICommandValidator<UpdateIngredientCommand>> _validators;
		private UpdateIngredientCommand _command;
		private UpdateIngredientCommandHandler _systemUnderTests;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_command = CommandFactory.EmptyUpdateIngredientCommand();
			var command = CommandFactory.ValidCreateIngredientCommand("MyName");
			_ingredient = new Ingredient(
				command.Id, command.Name, command.Allergens, command.Requirements,
				command.Shares, _eventPublisherMock.Object);
			_eventPublisherMock = new Mock<IEventPublisher>();
			_validators = new List<ICommandValidator<UpdateIngredientCommand>>
			{
				_validator.Object
			};
			_systemUnderTests = new UpdateIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators,
				_eventPublisherMock.Object);
		}

		[Test]
		public void GivenCommand_WhenCalled_UseValidators()
		{
			_validator.Setup(x => x.Validate(It.IsAny<UpdateIngredientCommand>()))
				.Returns(Result.Fail(0, ""));
			var result = _systemUnderTests.Handle(_command);
			using (new AssertionScope())
			{
				_validator.Verify(x => x.Validate(It.IsAny<UpdateIngredientCommand>()), Times.Once);
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be("");
				result.ResultCode.Should().Be(0);
			}
		}

		[Test]
		public void GivenValidCommand_WhenUpdated_ShouldPublishIngredientUpdatedEvent()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Identity<Guid>>()))
				.Returns(_ingredient);
			_systemUnderTests.Handle(_command);
			_eventPublisherMock.Verify(x => x.Rise(It.IsAny<string>()), Times.Once);
		}

		[Test]
		public void GivenCommand_WhenIngredientDoesNotExist_ReturnFailure()
		{
			var result = _systemUnderTests.Handle(_command);

			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be(FailMessages.DoesNotExist(nameof(Ingredient),
					nameof(UpdateIngredientCommand.Id), _command.Id.ToString()));
			}
		}

		[Test]
		public void GivenNewName_WhenAlreadyExist_ReturnFailure()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Identity<Guid>>()))
				.Returns(_ingredient);
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);

			var result = _systemUnderTests.Handle(_command);
			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be(FailMessages.AlreadyExist(nameof(Ingredient),
					nameof(UpdateIngredientCommand.Name), _command.Name));
			}
		}
	}
}