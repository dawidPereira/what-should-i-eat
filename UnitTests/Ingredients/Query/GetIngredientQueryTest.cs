using System;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Queries.Get;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Query
{
	[TestFixture]
	public class GetIngredientQueryTest
	{
		private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();
		private GetIngredientQuery _query;
		private Ingredient _ingredient;
		private GetIngredientQueryHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			_ingredient = FakeIngredientFactory.CreateValidIngredient("IngredientName", _ingredientRepositoryMock.Object);
            _query = new GetIngredientQuery(new Identity<Guid>(Guid.NewGuid()));
			_systemUnderTests = new GetIngredientQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenIngredientId_WhenNotExist_ShouldThrowArgumentNullException()
		{
			_systemUnderTests = new GetIngredientQueryHandler(Mock.Of<IIngredientRepository>());
			Action action = () => _systemUnderTests.Handle(_query);
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenIngredientId_WhenExist_ShouldReturnIngredient()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Identity<Guid>>()))
				.Returns(_ingredient);
			var result = _systemUnderTests.Handle(_query);
			result.Should().NotBeNull();
		}
	}
}