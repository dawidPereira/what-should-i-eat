using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Query.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.ValueObjects;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;

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
			_ingredient = new IngredientBuilder()
				.WithName("IngredientName")
				.WithMacroNutrient()
				.Build();
			_query = new GetIngredientQuery(new Id<Ingredient>(Guid.NewGuid()));
			_systemUnderTests = new GetIngredientQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenIngredientId_WhenExist_ShouldReturnIngredient()
		{
			_ingredientRepositoryMock.Setup(x => x.GetById(It.IsAny<Id<Ingredient>>()))
				.Returns(_ingredient);
			var result = _systemUnderTests.Handle(_query);
			result.Should().NotBeNull();
		}
		
		[Test]
		public void GivenIngredientId_WhenNotExist_ShouldReturnNull()
		{
			Action action = () => _systemUnderTests.Handle(_query);
			action.Should().Throw<ArgumentNullException>()
				.WithMessage($"Item with Id: {_query.Id.Value.ToString()} does not exist. (Parameter 'Ingredient')");
		}
	}
}