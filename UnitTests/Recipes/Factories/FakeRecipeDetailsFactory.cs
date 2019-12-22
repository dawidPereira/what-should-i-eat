using Domain.Recipes.Entities;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	public static class FakeRecipeDetailsFactory
	{
		public static RecipeDetails CreateValidRecipeDetails() =>
			new RecipeDetails(1, 15, 15, MealType.Breakfast);
	}
}