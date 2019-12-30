using System;
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

		public RecipeDetails Create(Guid recipeId)
		{
			var recipe = _recipeDetailsRepository.GetRecipeById(recipeId);
			var ingredients = _recipeDetailsRepository.GetAggregatedIngredientsDetailsByIds(recipe.RecipeIngredients);
			return RecipeDetails.FromRecipeAndIngredientsDetails(recipe, ingredients);
		}
	}
}