using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Dto;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Query.Handlers;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Query
{
	[TestFixture]
	internal class GetIngredientsBasicInfoQueryHandlerTests
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private GetIngredientsBasicInfoQuery _query;
		private GetIngredientsBasicInfoQueryHandler _systemUnderTests;
		private List<IngredientBasicInfo> _ingredientBasicInfos;
		
		[SetUp]
		public void SrtUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();

			_ingredientBasicInfos = new List<IngredientBasicInfo>
			{
				new IngredientBasicInfo {Name = "FirstName", Id = new Id<Ingredient>(Guid.NewGuid())},
				new IngredientBasicInfo {Name = "SecondName", Id = new Id<Ingredient>(Guid.NewGuid())}
			};
			_query = new GetIngredientsBasicInfoQuery();
			_systemUnderTests = new GetIngredientsBasicInfoQueryHandler(_ingredientRepositoryMock.Object);
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