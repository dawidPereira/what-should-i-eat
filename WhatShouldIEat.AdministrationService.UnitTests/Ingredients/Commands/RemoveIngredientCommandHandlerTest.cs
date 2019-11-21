using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	internal class RemoveIngredientCommandHandlerTest
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private RemoveIngredientCommand _command;
		private RemoveIngredientCommandHandler _systemUnderTest;
		private Ingredient _ingredient;
		
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_command = new RemoveIngredientCommand
			{
				Id = new Id<Ingredient>(Guid.NewGuid())
			};
			
			_ingredient = new IngredientBuilder()
				.WithName("MyName")
				.WithMacroNutrient()
				.Build();
			
			_systemUnderTest = new RemoveIngredientCommandHandler(_ingredientRepositoryMock.Object);
		}


		[Test]
		public void GivenIngredientId_WhenIngredientNotExist_ShouldReturnFailure()
		{
			var result  = _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
		}
		
		[Test]
		public void GivenIngredientId_WhenIngredientExist_ShouldReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Id<Ingredient>>()))
				.Returns(_ingredient);

			var result  = _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}
	}
}