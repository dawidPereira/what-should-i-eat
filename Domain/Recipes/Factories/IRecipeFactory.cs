using System;
using System.Collections.Generic;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Factories
{
	public interface IRecipeFactory
	{
		Recipe Create(Guid id, 
			string name, 
			string description,
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients);
		
		Recipe GetRecipe(Guid id, 
			string name, 
			string description,
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients);
	}
}