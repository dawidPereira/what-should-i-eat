using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Recipes.Commands;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Builders;

namespace WhatShouldIEat.AdministrationService.Tests.Recipe.Factories
{
	using  Recipe = Administration.Domain.Recipes.Entities.Recipe;

	internal static class RecipeFactory
	{
		internal static Recipe Create()
		{
			var ingredient = new IngredientBuilder()
				.WithMacroNutrient()
				.Build();
			
			var ingredients = new List<RecipeIngredient>
			{
				new RecipeIngredient(ingredient.Id,Guid.NewGuid(),100, ingredient)
			};
			
			var command = new CreateRecipeCommand
			{
				Id = Guid.NewGuid(),
				Name = "TestRecipe",
				Description = string.Empty,
				RecipeDetails = new RecipeDetails(1, 1, 1, new List<MealType> {MealType.Breakfast}),
				RecipeIngredients = ingredients
			};

			return Recipe.Create(command);
		}
	}
}