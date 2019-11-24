using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientsBasicInfos;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Query
{
	[TestFixture]
	internal class GetIngredientsBasicInfoQueryHandlerTests
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private GetIngredientsBasicInfosQuery _query;
		private GetIngredientsBasicInfosQueryHandler _systemUnderTests;
		private List<IngredientBasicInfo> _ingredientBasicInfos;
		
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();

			_ingredientBasicInfos = new List<IngredientBasicInfo>
			{
				new IngredientBasicInfo {Name = "FirstName", Id = Guid.NewGuid()},
				new IngredientBasicInfo {Name = "SecondName", Id = Guid.NewGuid()}
			};
			_query = new GetIngredientsBasicInfosQuery();
			_systemUnderTests = new GetIngredientsBasicInfosQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void Called_WhenItemExist_ShouldReturnNull()
		{
			_ingredientRepositoryMock.Setup(x => x.GetAllBasicInfos())
				.Returns(_ingredientBasicInfos);
			
			var result = _systemUnderTests.Handle(_query);
			result.Count.Should().Be(2);
		}
		
		[Test]
		public void Called_WhenNoItems_ShouldReturnEmptyList()
		{
			var result = _systemUnderTests.Handle(_query);
			result.Should().BeNullOrEmpty();
		}
	}
}