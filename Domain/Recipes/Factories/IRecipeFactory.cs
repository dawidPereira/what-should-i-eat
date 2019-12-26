using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Factories
{
	public interface IRecipeFactory
	{
		Recipe Create(Guid id, 
			string name, 
			string description,
			RecipeInfo recipeInfo,
			IEnumerable<RecipeIngredient> recipeIngredients,
			IEventPublisher eventPublisher,
			IRecipeRepository recipeRepository);
	}
}