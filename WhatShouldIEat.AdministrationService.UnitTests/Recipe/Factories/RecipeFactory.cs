﻿using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Create;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Recipe.Factories
{
	internal static class RecipeFactory
	{
		internal static Administration.Domain.Recipes.Entities.Recipe Create()
		{
			var createIngredientCommand = CommandFactory.CreateValidIngredientFactory("TesIngredient");
			var ingredient = Ingredient.Create(
				createIngredientCommand.Id,
				createIngredientCommand.Name,
				createIngredientCommand.Allergens,
				createIngredientCommand.Requirements,
				createIngredientCommand.MacroNutrientsParticipation);
			
			var ingredients = new List<RecipeIngredient>
			{
				new RecipeIngredient(ingredient.Id,Guid.NewGuid(),100, ingredient)
			};
			
			var command = new CreateRecipeCommand
			{
				Id = Guid.NewGuid(),
				Name = "TestRecipe",
				Description = string.Empty,
				RecipeDetails = new RecipeDetails(1, 1, 1, MealType.Breakfast),
				RecipeIngredients = ingredients
			};

			return Administration.Domain.Recipes.Entities.Recipe.Create(
				command.Id, command.Description, command.Description, command.RecipeDetails, command.RecipeIngredients);
		}
	}
}