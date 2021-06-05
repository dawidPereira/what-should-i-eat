using System;
using System.Threading.Tasks;
using Domain.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal class FakeRecipeFactory
	{
		private readonly Recipe.RecipeFactory _recipeFactory;
		private readonly IRecipeRepository _recipeRepository;
		private readonly FakeRecipeIngredientsFactory _fakeRecipeIngredientsFactory;

		public FakeRecipeFactory(IRecipeRepository recipeRepository, IEventPublisher eventPublisher, IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_recipeFactory = new Recipe.RecipeFactory(recipeRepository, eventPublisher);
			_fakeRecipeIngredientsFactory = new FakeRecipeIngredientsFactory(ingredientRepository);
		}

		public async Task<Recipe> CreateValidRecipe(string name, string description) =>
			await _recipeFactory.Create(Guid.NewGuid(),
				name,
				description,
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList());

		public async Task<Recipe> CreateValidRecipe(string name, string description, IEventPublisher eventPublisher) =>
			await _recipeFactory.Create(Guid.NewGuid(),
				name,
				description,
				"",
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList());
	}
}
