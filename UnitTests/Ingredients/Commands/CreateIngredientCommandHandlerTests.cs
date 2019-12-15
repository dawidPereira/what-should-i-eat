using System.Collections.Generic;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.RecipesDetails.Ingredients.Commands.Create;
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
	internal class CreateIngredientCommandTests
	{
		private CreateIngredientCommandHandler _systemUnderTest;
		private CreateIngredientCommand _command;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private IEnumerable<ICommandValidator<CreateIngredientCommand>> _validators;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = CommandFactory.EmptyCreateIngredientCommand();
			_validators = new List<ICommandValidator<CreateIngredientCommand>>
			{
				new UniqueIngredientByNameValidator(_ingredientRepositoryMock.Object)
			};
			_systemUnderTest = new CreateIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators);
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