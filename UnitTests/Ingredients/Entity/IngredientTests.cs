﻿using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Entities.MacroNutrients;
using Domain.Ingredients.Events;
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
		private Ingredient _systemUnderTest;


		[SetUp]
		public void SetUp()
		{
			_eventPublisherMock = new Mock<IEventPublisher>();
			_systemUnderTest = FakeIngredientFactory.CreateValidIngredient(IngredientName);
		}

		[Test]
		public void Ingredient_WhenCreated_ShouldPublishIngredientCreatedEvent()
		{
			FakeIngredientFactory.CreateValidIngredient(IngredientName);
			_eventPublisherMock.Verify(x => x.Publish(It.IsAny<IngredientCreatedEvent>()), Times.Once);
		}

		[Test]
		public void GivenEmptyName_DuringIngredientCreating_ShouldThrowArgumentNullException()
		{
			Action action = () => FakeIngredientFactory.CreateValidIngredient(null);
			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void GivenIncorrectId_DuringIngredientCreating_ShouldThrowArgumentException()
		{
			Action action = () => FakeIngredientFactory.CreateIngredientWithInvalidId(IngredientName);
			action.Should().Throw<ArgumentException>();
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
				result[MacroNutrient.Carbohydrate].Should().Be(20);
				result[MacroNutrient.Fat].Should().Be(20);
				result[MacroNutrient.Protein].Should().Be(20);
			}
		}

		[Test]
		public void CalculateCaloriesPerGram_WhenCalled_ShouldReturnProperValue()
		{
			_systemUnderTest = FakeIngredientFactory.CreateIngredientWithOneShare(
				IngredientName, MacroNutrient.Carbohydrate);
			var result = _systemUnderTest.CalculateCalories(100);
			result.Should().Be(80);
		}
	}
}