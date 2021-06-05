using System;
using System.Threading.Tasks;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.RecipeDetailsFactories
{
	public class RecipeDetailsFactory : IRecipeDetailsFactory
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public RecipeDetailsFactory(IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public async Task<RecipeDetails> Create(Guid recipeId)
		{
			var recipe = await _recipeDetailsRepository.GetRecipeById(recipeId);
			var ingredients = await _recipeDetailsRepository.GetAggregatedIngredientsDetailsByIds(recipe.RecipeIngredients);
			return RecipeDetails.FromRecipeAndIngredientsDetails(recipe, ingredients);
		}
	}
}
