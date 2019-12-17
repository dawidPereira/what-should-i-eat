using System;
using Domain.Common.Mediators.Events;
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
		private readonly Mock<IEventPublisher> _eventPublisher = new Mock<IEventPublisher>();
		private GetIngredientQuery _query;
		private Ingredient _ingredient;
		private GetIngredientQueryHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			var command = CommandFactory.ValidCreateIngredientCommand("IngredientName");
            _ingredient = new Ingredient(
	            command.Id, command.Name, command.Allergens, command.Requirements, command.Shares, _eventPublisher.Object);
            _query = new GetIngredientQuery(Guid.NewGuid());
			_systemUnderTests = new GetIngredientQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenIngredientId_WhenExist_ShouldReturnIngredient()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
				.Returns(_ingredient);
			var result = _systemUnderTests.Handle(_query);
			result.Should().NotBeNull();
		}
		
		[Test]
		public void GivenIngredientId_WhenNotExist_ShouldReturnNull()
		{
			Action action = () => _systemUnderTests.Handle(_query);
			action.Should().Throw<ArgumentNullException>()
				.WithMessage($"Item with Id: {_query.IngredientId.ToString()} does not exist. (Parameter 'Ingredient')");
		}
	}
}