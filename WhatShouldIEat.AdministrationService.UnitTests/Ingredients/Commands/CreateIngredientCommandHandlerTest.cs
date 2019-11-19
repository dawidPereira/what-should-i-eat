using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	internal class CreateIngredientCommandTest
	{
		private CreateIngredientCommandHandler _systemUnderTest;
		private CreateIngredientCommand _createIngredientCommand;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_createIngredientCommand = CommandFactory.EmptyCreateIngredientCommand();
			_systemUnderTest = new CreateIngredientCommandHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenProperData_WhenIngredientNotExist_ShouldReturnResultOk()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			var result = _systemUnderTest.Handle(_createIngredientCommand);
			result.IsSuccess.Should().BeTrue();
		}

		[Test]
		public void GivenProperData_WhenIngredientExist_ShouldReturnResultFailure()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			var result = _systemUnderTest.Handle(_createIngredientCommand);
			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be($"Ingredient {_createIngredientCommand.Name}, already exist.");
			}
		}
	}
}