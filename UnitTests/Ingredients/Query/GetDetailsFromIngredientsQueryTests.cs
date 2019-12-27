using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Queries.GetDetailsFormIngredients;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Query
{
	[TestFixture]
	public class GetDetailsFromIngredientsQueryTests
	{
		private const Allergen Allergens = Allergen.Gluten | Allergen.Milk;
		private const Requirement Requirements = Requirement.Ecological | Requirement.ForVegan;
		private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();
		private readonly Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();
		private readonly List<Identity<Guid>> _ids = new List<Identity<Guid>>
		{
			new Identity<Guid>(Guid.NewGuid()),
			new Identity<Guid>(Guid.NewGuid()),
			new Identity<Guid>(Guid.NewGuid())
		};

		private GetDetailsFromIngredientsQueryHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock.Setup(x => x.GetByIds(It.IsAny<ICollection<Identity<Guid>>>()))
				.Returns(FakeIngredientFactory.CreateIngredientsCollection(_ids, _ingredientRepositoryMock.Object));
			_systemUnderTests = new GetDetailsFromIngredientsQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenValidIngredient_WhenCommandHandled_ReturnValidAggregatedIngredientsDetails()
		{
			var query = QueryFactory.GetDetailsFromIngredientsQuery(_ids);
			var result = _systemUnderTests.Handle(query);
			using (new AssertionScope())
			{
				result.Allergens.Should().Be(Allergens);
				result.Requirements.Should().Be(Requirements);
				result.Calories.Should().Be(1785);
				result.MacroNutrientQuantity[MacroNutrient.Carbohydrate].Should().Be(70);
				result.MacroNutrientQuantity[MacroNutrient.Fat].Should().Be(105);
				result.MacroNutrientQuantity[MacroNutrient.Protein].Should().Be(140);
			}
		}
	}
}