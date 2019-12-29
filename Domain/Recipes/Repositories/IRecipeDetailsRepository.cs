using System;
using System.Collections.Generic;
using Domain.Recipes.Entities;
using Domain.RecipesDetails.Entities;

namespace Domain.Recipes.Repositories
{
	public interface IRecipeDetailsRepository
	{
		void Add(RecipeDetails recipeDetails);
		
		void Remove(string key);
		
		void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos);

		Recipe GetRecipeById(Guid recipeId);

		ICollection<Guid> GetAllRecipesIds();

		AggregatedIngredientsDetails GetAggregatedIngredientsDetailsByIds(ICollection<Guid> ingredientsIds);
	}
}