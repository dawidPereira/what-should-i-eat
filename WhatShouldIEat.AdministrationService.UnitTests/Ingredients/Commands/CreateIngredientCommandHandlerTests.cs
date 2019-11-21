using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	internal class CreateIngredientCommandTests
	{
		private CreateIngredientCommandHandler _systemUnderTest;
		private CreateIngredientCommand _command;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = CommandFactory.EmptyCreateIngredientCommand();
			_systemUnderTest = new CreateIngredientCommandHandler(_ingredientRepositoryMock.Object);
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