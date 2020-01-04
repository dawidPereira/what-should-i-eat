using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.Repositories
{
	public interface  IRecipeDetailsRepository
	{
		void CreateNewOrUpdateExisting(RecipeDetails recipeDetails);

		void CreateNewOrUpdateExistingRange(IEnumerable<RecipeDetails> recipeDetails);
		
		void Remove(string key);

		void RemoveRange(IEnumerable<RecipeDetails> recipeDetails);

		IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId);

		IEnumerable<Guid> GetAllRecipesIds();

		IEnumerable<Guid> GetRecipeIdsByIngredientId(Guid ingredientId);

		Recipe GetRecipeById(Guid id);

		AggregatedIngredientsDetails GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams);
	}
}