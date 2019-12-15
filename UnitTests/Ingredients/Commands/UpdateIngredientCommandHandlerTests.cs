using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.RecipesDetails.Ingredients.Commands.Update;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	public class UpdateIngredientCommandHandlerTests
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IEventPublisher> _eventPublisherMock;
		private UpdateIngredientCommand _command;
		private UpdateIngredientCommandHandler _systemUnderTests;
		private IEnumerable<ICommandValidator<UpdateIngredientCommand>> _validators;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = CommandFactory.EmptyUpdateIngredientCommand();
			var command = CommandFactory.CreateValidIngredientFactory("MyName");
            _ingredient = Ingredient.Create(
	            command.Id, command.Name, command.Allergens, command.Requirements, command.MacroNutrientsParticipation);
            _eventPublisherMock = new Mock<IEventPublisher>();
			_validators = new List<ICommandValidator<UpdateIngredientCommand>>
			{
				new IngredientExistValidator(_ingredientRepositoryMock.Object),
				new UniqueIngredientNameValidator(_ingredientRepositoryMock.Object)
			};
			_systemUnderTests = new UpdateIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators, _eventPublisherMock.Object);
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
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
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
		
		[Test]
		public void GivenProperCommand_WhenNoErrors_ReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(_ingredient);
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			
			var result = _systemUnderTests.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}
	}
}