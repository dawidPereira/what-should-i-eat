using System;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Recipes.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Commands.Factories
{
	public class CommandsFactory
	{
		private FakeRecipeIngredientsFactory _fakeRecipeIngredientsFactory;

		public CommandsFactory(IIngredientRepository ingredientRepository)
		{
			_fakeRecipeIngredientsFactory = new FakeRecipeIngredientsFactory(ingredientRepository);
		}
		public CreateRecipeCommand CreateRecipeCommand()
		{
			return new CreateRecipeCommand(Guid.NewGuid(), 
				"",
				"", 
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList());
		}
	}
}