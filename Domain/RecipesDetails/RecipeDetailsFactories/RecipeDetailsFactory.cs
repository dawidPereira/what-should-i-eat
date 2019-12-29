using System;
using Domain.Recipes.Repositories;
using Domain.RecipesDetails.Entities;

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
			var recipeIngredientsIds = recipe.RecipeIngredients.GetIngredientsIds();
			var ingredients = _recipeDetailsRepository.GetAggregatedIngredientsDetailsByIds(recipeIngredientsIds);
			return RecipeDetails.FromRecipeAndIngredientsDetails(recipe, ingredients);
		}
	}
}