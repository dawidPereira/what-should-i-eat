using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	internal class FakeRecipeFactory
	{
		private readonly Recipe.RecipeFactory _recipeFactory;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEventPublisher _eventPublisher;
		private readonly FakeRecipeIngredientsFactory _fakeRecipeIngredientsFactory;

		public FakeRecipeFactory(IRecipeRepository recipeRepository, IEventPublisher eventPublisher, IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_eventPublisher = eventPublisher;
			_recipeFactory = new Recipe.RecipeFactory(recipeRepository, eventPublisher);
			_fakeRecipeIngredientsFactory = new FakeRecipeIngredientsFactory(ingredientRepository);
		}

		public Recipe CreateValidRecipe(string name, string description) =>
			_recipeFactory.Create(Guid.NewGuid(),
				name,
				description,
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList(),
				_eventPublisher,
				_recipeRepository);
		
		public Recipe CreateValidRecipe(string name, string description, IEventPublisher eventPublisher) =>
			_recipeFactory.Create(Guid.NewGuid(),
				name,
				description,
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList(),
				eventPublisher,
				_recipeRepository);
	}
}