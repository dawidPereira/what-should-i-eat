﻿using Domain.Common.Mediators.Events;
using Domain.Common.Messages;
using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	internal class CreateIngredientCommandTests
	{
		private CreateIngredientCommandHandler _systemUnderTest;
		private CreateIngredientCommand _command;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IIngredientFactory> _ingredientFactoryMock;
		private Mock<IEventPublisher> _iEventPublisherMock;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientFactoryMock = new Mock<IIngredientFactory>();
			_iEventPublisherMock = new Mock<IEventPublisher>();
			_command = CommandFactory.EmptyCreateIngredientCommand();
			_systemUnderTest = new CreateIngredientCommandHandler(
				_ingredientRepositoryMock.Object, _ingredientFactoryMock.Object, _iEventPublisherMock.Object);
		}

		[Test]
		public void GivenProperData_WhenIngredientNotExist_ShouldReturnResultOk()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			var result = _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}
		
		[Test]
		public void GivenValidIngredient_WhenCreated_ShouldRiseEvents()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			_iEventPublisherMock.Verify(x => x.Rise(It.IsAny<string>()), Times.Once);
		}

		[Test]
		public void GivenProperData_WhenIngredientExist_ShouldReturnResultFailure()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			var result = _systemUnderTest.Handle(_command);
			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be(FailMessages.AlreadyExist(nameof(Ingredient), 
					nameof(CreateIngredientCommand.Name), _command.Name));
			}
		}
	}
}