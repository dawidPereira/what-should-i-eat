using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;
using Moq;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal class FakeRecipeIngredientsFactory
	{
		private RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;
		private readonly IIngredientRepository _ingredientRepository;

		public FakeRecipeIngredientsFactory(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(_ingredientRepository);
		}
		public IEnumerable<RecipeIngredient> CreateValidRecipeIngredientList()
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