using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.ValueObjects;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	public class UpdateIngredientCommandHandlerTests
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private UpdateIngredientCommand _command;
		private UpdateIngredientCommandHandler _systemUnderTests;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = CommandFactory.EmptyUpdateIngredientCommand();
			_ingredient = new IngredientBuilder()
				.WithMacroNutrient()
				.WithName("IngredientName")
				.Build();
			_systemUnderTests = new UpdateIngredientCommandHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenProperCommand_WhenIngredientDoesNotExist_ReturnFailure()
		{
			var result = _systemUnderTests.Handle(_command);

			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be($"Ingredient with Id: {_command.Id.Value}, does not exist.");
			}
		}
		
		[Test]
		public void GivenNewName_WhenAlreadyExist_ReturnFailure()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Id<Ingredient>>()))
				.Returns(_ingredient);
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			
			var result = _systemUnderTests.Handle(_command);
			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.Message.Should().Be($"Ingredient {_command.Name}, already exist.");
			}
		}
		
		[Test]
		public void GivenProperCommand_WhenNoErrors_ReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Id<Ingredient>>()))
				.Returns(_ingredient);
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			
			var result = _systemUnderTests.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}
	}
}