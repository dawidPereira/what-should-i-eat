using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	public class UpdateIngredientCommandHandlerTests
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private UpdateIngredientCommand _command;
		private UpdateIngredientCommandHandler _systemUnderTests;
		private IEnumerable<ICommandValidator<UpdateIngredientCommand>> _validators;
		private Ingredient _ingredient;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = CommandFactory.EmptyUpdateIngredientCommand();
			_ingredient = Ingredient.Create(CommandFactory.CreateValidIngredientFactory("IngredientName"));
			_validators = new List<ICommandValidator<UpdateIngredientCommand>>
			{
				new IngredientExistValidator(_ingredientRepositoryMock.Object),
				new UniqueIngredientNameValidator(_ingredientRepositoryMock.Object)
			};
			_systemUnderTests = new UpdateIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators);
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