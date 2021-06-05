using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Factories
{
	public interface IRecipeFactory
	{
		Task<Recipe> Create(Guid id,
			string name,
			string description,
			string imageUrl,
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients);

		Recipe GetRecipe(Guid id,
			string name,
			string description,
			string imageUrl,
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients);
	}
}
