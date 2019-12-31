using System;
using Domain.Events;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Events;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Entity
{
	[TestFixture]
	internal class IngredientTests
	{
		private const string IngredientName = "IngredientName";
		private Mock<IEventPublisher> _eventPublisherMock;
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Ingredient _systemUnderTest;


		[SetUp]
		public void SetUp()
		{
			_eventPublisherMock = new Mock<IEventPublisher>();
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(false);
			_systemUnderTest = FakeIngredientFactory.CreateValidIngredientWithEventPublisher(IngredientName, _ingredientRepositoryMock.Object, _eventPublisherMock.Object);
		}

		[Test]
		public void Ingredient_WhenCreated_ShouldPublishIngredientCreatedEvent() => 
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<IngredientCreatedEvent>()), Times.Once);

		[Test]
		public void GivenEmptyName_DuringIngredientCreating_ShouldThrowArgumentNullException()
		{
			Action action = () => FakeIngredientFactory.CreateValidIngredient(null, _ingredientRepositoryMock.Object);
			action.Should().Throw<ArgumentNullException>();
		}
		
		[Test]
		public void Ingredient_WhenUpdated_ShouldPublishIngredientUpdatedEvent()
		{
			_systemUnderTest.Update(
				IngredientName, Allergen.Gluten, Requirement.None, _systemUnderTest.MacroNutrientsSharesCollection);
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<IngredientUpdatedEvent>()), Times.Once);
		}

		[Test]
		public void GivenEmptyName_DuringIngredientUpdating_ShouldThrowArgumentNullException()
		{
			Action action = () => _systemUnderTest.Update(
				null, Allergen.Gluten, Requirement.None, _systemUnderTest.MacroNutrientsSharesCollection);
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenOneHundredGrams_WhenShareEqualsTwentyPercent_ShouldReturnTwentyGrams()
		{
			var result = _systemUnderTest.GetMacroNutrientQuantity(100);
			using (new AssertionScope())
			{
				result[(int)MacroNutrient.Carbohydrate].Should().Be(20);
				result[(int)MacroNutrient.Fat].Should().Be(20);
				result[(int)MacroNutrient.Protein].Should().Be(30);
			}
		}

		[Test]
		public void CalculateCaloriesPerGram_WhenCalled_ShouldReturnProperValue()
		{
			_systemUnderTest = FakeIngredientFactory.CreateIngredientWithOneShare(
				IngredientName, MacroNutrient.Carbohydrate, _ingredientRepositoryMock.Object);
			var result = _systemUnderTest.CalculateCalories(100);
			result.Should().Be(80);
		}
	}
}