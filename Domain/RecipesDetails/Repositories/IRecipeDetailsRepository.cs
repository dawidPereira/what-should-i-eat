using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Repositories
{
	public interface IRecipeDetailsRepository
	{
		void Add(RecipeDetails recipeDetails);
		
		void Remove(string key);
		
		void AddRange(IEnumerable<RecipeDetails> recipeSearchInfos);

		IDictionary<Guid, double> GetRecipeIngredientById(Guid recipeId);

		IEnumerable<Guid> GetAllRecipesIds();
		
		Recipe GetRecipeById(Guid id);

		AggregatedIngredientsDetails GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams);
	}
}