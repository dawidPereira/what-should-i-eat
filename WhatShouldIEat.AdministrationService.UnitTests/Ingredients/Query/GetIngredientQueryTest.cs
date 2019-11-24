using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientQuery;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Query
{
	[TestFixture]
	public class GetIngredientQueryTest
	{
	
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private GetIngredientQuery _query;
		private GetIngredientQueryHandler _systemUnderTests;
		private Ingredient _ingredient;
	
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredient = Ingredient.Create(CommandFactory.CreateValidIngredientFactory("IngredientName"));
			_query = new GetIngredientQuery
			{
				Id = Guid.NewGuid()
			};
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
				.WithMessage($"Item with Id: {_query.Id.ToString()} does not exist. (Parameter 'Ingredient')");
		}
	}
}