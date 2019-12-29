using System;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.RecipeDetailsFactories
{
	public interface IRecipeDetailsFactory
	{
		RecipeDetails Create(Guid recipeId);
	}
}