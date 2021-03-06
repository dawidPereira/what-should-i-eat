﻿using System;
using Domain.Common.Messages;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands.Update
{
	[TestFixture]
	public class UniqueIngredientByNameValidatorTests
	{
		private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();

		[SetUp]
		public void SetUp()
		{
			var ingredient = FakeIngredientFactory.CreateValidIngredient("Ingredient", _ingredientRepositoryMock.Object);
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(ingredient);
		}

		[Test]
		public void GivenExistingName_WhenUpdating_ShouldReturnFailResult()
		{
			var systemUnderTest = new UniqueIngredientByNameValidator(_ingredientRepositoryMock.Object);
			var result = systemUnderTest.Validate(CommandFactory.EmptyUpdateIngredientCommand());

			using (new AssertionScope())
			{
				result.IsFailure.Should().BeTrue();
				result.ResultCode.Should().Be(ResultCode.BadRequest);
			}
		}
	}
}