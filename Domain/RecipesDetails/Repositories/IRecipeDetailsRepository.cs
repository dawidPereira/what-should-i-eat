using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.RecipesDetails.Repositories
{
	public interface  IRecipeDetailsRepository
	{
		Task CreateNewOrReplaceExisting(RecipeDetails recipeDetails);

		Task CreateNewOrReplaceExistingRange(IEnumerable<RecipeDetails> recipeDetails);

		Task RemoveById(Guid recipeDetailsId);

		void RemoveRange(IEnumerable<RecipeDetails> recipeDetails);

		IDictionary<Guid, double> GetRecipeIngredientByRecipeId(Guid recipeId);

		Task<IEnumerable<Guid>> GetAllRecipesIds();

		Task<IEnumerable<Guid>> GetRecipeIdsByIngredientId(Guid ingredientId);

		Task<Recipe> GetRecipeById(Guid id);

		Task<AggregatedIngredientsDetails> GetAggregatedIngredientsDetailsByIds(IDictionary<Guid, double> ingredientsGrams);

		IEnumerable<RecipeDetails> FindRecipesDetails(RecipeSearchFilterCriteria filterCriteria);
	}
}
