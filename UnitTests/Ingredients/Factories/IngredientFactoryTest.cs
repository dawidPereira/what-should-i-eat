using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories
{
	[TestFixture]
	public class IngredientFactoryTest
	{
		private readonly Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();
		private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();
		
		[Test]
		public void GivenExistedIngredientName_DuringCreating_ShouldThrowArgumentException()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistByName(It.IsAny<string>()))
				.Returns(true);
			Action action = () => new IngredientFactory(_ingredientRepositoryMock.Object);
			action.Should().Throw<ArgumentException>();
		}
	}
}