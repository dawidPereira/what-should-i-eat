using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Events;
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

		private readonly Mock<ICommandValidator<UpdateIngredientCommand>> _validator = new Mock<ICommandValidator<UpdateIngredientCommand>>();

		private Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();
		private IEnumerable<ICommandValidator<UpdateIngredientCommand>> _validators;
		private UpdateIngredientCommand _command;
		private UpdateIngredientCommandHandler _systemUnderTests;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_command = CommandFactory.EmptyUpdateIngredientCommand();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_validator.Setup(x => x.Validate(It.IsAny<UpdateIngredientCommand>()))
				.Returns(Result.Ok);
			_validators = new List<ICommandValidator<UpdateIngredientCommand>>
			{
				_validator.Object
			};
			_ingredient = FakeIngredientFactory.CreateValidIngredient("Ingredient", _ingredientRepositoryMock.Object);
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
		public void GivenValidCommand_WhenUpdated_ShouldPublishIngredientUpdatedEvent()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(_ingredient);
			_systemUnderTests.Handle(_command);
			_eventPublisherMock.Verify(x => x.Rise(), Times.Once);
		}
	}
}