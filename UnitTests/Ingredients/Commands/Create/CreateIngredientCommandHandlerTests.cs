using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Events;
using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands.Create
{
	[TestFixture]
	internal class CreateIngredientCommandTests
	{
		private CreateIngredientCommandHandler _systemUnderTest;
		private CreateIngredientCommand _command;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IIngredientFactory> _ingredientFactoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private List<ICommandValidator<CreateIngredientCommand>> _validators;


		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientFactoryMock = new Mock<IIngredientFactory>();
			_eventPublisherMock = new Mock<IEventPublisher>();
			_validators = new List<ICommandValidator<CreateIngredientCommand>>
			{
				new UniqueIngredientByNameValidator(_ingredientRepositoryMock.Object)
			};
			_command = CommandFactory.EmptyCreateIngredientCommand();
			_systemUnderTest = new CreateIngredientCommandHandler(
				_ingredientFactoryMock.Object, _eventPublisherMock.Object, _validators);
		}

		[Test]
		public async Task GivenProperData_WhenIngredientNotExist_ShouldReturnResultOk()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			var result = await _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}

		[Test]
		public void GivenValidIngredient_WhenCreated_ShouldRiseEvents()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			_systemUnderTest.Handle(_command);
			_eventPublisherMock.Verify(x => x.Rise(), Times.Once);
		}

		[Test]
		public async Task GivenProperData_WhenIngredientExist_ShouldReturnResultFailure()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			var result = await _systemUnderTest.Handle(_command);
			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be(FailMessages.AlreadyExist(nameof(Ingredient),
					nameof(CreateIngredientCommand.Name), _command.Name));
			}
		}
	}
}
