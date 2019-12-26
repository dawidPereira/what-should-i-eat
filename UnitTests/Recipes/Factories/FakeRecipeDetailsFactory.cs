using Domain.Recipes.Entities;

namespace WhatShouldIEat.AdministrationService.Tests.Recipes.Factories
{
	public static class FakeRecipeDetailsFactory
	{
		public static RecipeInfo CreateValidRecipeDetails() =>
			new RecipeInfo(1, 15, 15, MealType.Breakfast);
	}
}