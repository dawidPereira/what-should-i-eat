using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;
using Moq;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal static  class FakeRecipeIngredientsFactory
	{
		private static RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;
		private static Mock<IIngredientRepository> _ingredientRepositoryMock;

		static FakeRecipeIngredientsFactory()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(_ingredientRepositoryMock.Object);
		}
		public static ICollection<RecipeIngredient> CreateValidRecipeIngredientList()
		{
			return new List<RecipeIngredient>
			{
				_recipeIngredientFactory.Create(new Identity<Guid>(Guid.NewGuid()), 100),
				_recipeIngredientFactory.Create(new Identity<Guid>(Guid.NewGuid()), 100),
				_recipeIngredientFactory.Create(new Identity<Guid>(Guid.NewGuid()), 100)
			};
		}
	}
}