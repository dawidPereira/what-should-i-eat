using System;
using System.Collections.Generic;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Dtos;
using Domain.Recipes.Entities;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal class FakeRecipeIngredientsFactory
	{
		private readonly RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;

		public FakeRecipeIngredientsFactory(IIngredientRepository ingredientRepository)
		{
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(ingredientRepository);
		}
		public IEnumerable<RecipeIngredient> CreateValidRecipeIngredientList() =>
			new List<RecipeIngredient>
			{
				_recipeIngredientFactory.Create(Guid.NewGuid(), 100),
				_recipeIngredientFactory.Create(Guid.NewGuid(), 100),
				_recipeIngredientFactory.Create(Guid.NewGuid(), 100)
			};

		public IEnumerable<RecipeIngredientDto> CreateValidRecipeIngredientDictionary() =>
			new List<RecipeIngredientDto>
			{
				new RecipeIngredientDto(Guid.NewGuid(), 100), 
				new RecipeIngredientDto(Guid.NewGuid(), 100), 
				new RecipeIngredientDto(Guid.NewGuid(), 100)
			};
	}
}