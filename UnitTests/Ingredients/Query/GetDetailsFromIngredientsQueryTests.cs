using System;
using System.Collections.Generic;
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
		private readonly List<Guid> _ids = new List<Guid>
		{
			Guid.NewGuid(),
			Guid.NewGuid(),
			Guid.NewGuid()
		};

		private GetAggregatedIngredientsDetailsQueryHandler _systemUnderTests;

		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock.Setup(x => x.GetByIds(It.IsAny<ICollection<Guid>>()))
				.Returns(FakeIngredientFactory.CreateIngredientsCollection(_ids, _ingredientRepositoryMock.Object));
			_systemUnderTests = new GetAggregatedIngredientsDetailsQueryHandler(_ingredientRepositoryMock.Object);
		}

		[Test]
		public void GivenValidIngredient_WhenQueryHandled_ReturnValidAggregatedIngredientsDetails()
		{
			var query = QueryFactory.GetDetailsFromIngredientsQuery(_ids);
			var result = _systemUnderTests.Handle(query);
			using (new AssertionScope())
			{
				result.Allergens.Should().Be(Allergens.ToString());
				result.Requirements.Should().Be(Requirements.ToString());
				result.Calories.Should().Be(1785);
				result.MacroNutrientQuantity[MacroNutrient.Carbohydrate.ToString()].Should().Be(70);
				result.MacroNutrientQuantity[MacroNutrient.Fat.ToString()].Should().Be(105);
				result.MacroNutrientQuantity[MacroNutrient.Protein.ToString()].Should().Be(140);
			}
		}
	}
}