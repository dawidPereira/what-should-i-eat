using System;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Commands.Create;
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
		public CreateRecipeCommand CreateRecipeCommand(string name, string description)
		{
			return new CreateRecipeCommand(Guid.NewGuid(), 
				name,
				description, 
				FakeRecipeDetailsFactory.CreateValidRecipeDetails(),
				_fakeRecipeIngredientsFactory.CreateValidRecipeIngredientList());
		}
	}
}