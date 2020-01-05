using System;
using System.Collections.Generic;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Repositories
{
	public interface  IRecipeDetailsRepository
	{
		void CreateNewOrReplaceExisting(RecipeDetails recipeDetails);

		void CreateNewOrReplaceExistingRange(IEnumerable<RecipeDetails> recipeDetails);
		
		void RemoveById(Guid recipeDetailsId);

		void RemoveRange(IEnumerable<RecipeDetails> recipeDetails);

		IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId);

		IEnumerable<Guid> GetAllRecipesIds();

		IEnumerable<Guid> GetRecipeIdsByIngredientId(Guid ingredientId);

		Recipe GetRecipeById(Guid id);

		AggregatedIngredientsDetails GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams);

		IEnumerable<RecipeDetails> FindRecipesDetails(RecipeSearchFilterCriteria filterCriteria);
	}
}