using System;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Factories
{
	public interface IRecipeIngredientFactory
	{
		RecipeIngredient Create(Guid ingredientId, double grams);
	}
}