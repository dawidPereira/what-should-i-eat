using System.Collections.Generic;
using System.Linq;
using Domain.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Infrastructure.Mappers.Recipes
{
	public class RecipeMapper : IRecipeMapper
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;

		public RecipeMapper(IEventPublisher eventPublisher, IIngredientRepository ingredientRepository)
		{
			_eventPublisher = eventPublisher;
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(ingredientRepository);
		}

		public Recipe ToDomainRecipe(Entities.Recipe.Recipe recipe, IRecipeRepository recipeRepository)
		{
			var recipeFactory = new Recipe.RecipeFactory(recipeRepository, _eventPublisher);
			return recipeFactory.GetRecipe(recipe.Id,
				recipe.Name,
				recipe.Description,
				ToDomainRecipeInfo(recipe.RecipeInfo),
				ToDomainRecipeIngredients(recipe.RecipeIngredients));
		}

		private IEnumerable<RecipeIngredient> ToDomainRecipeIngredients(IEnumerable<Entities.Recipe.RecipeIngredient> recipeIngredients) =>
			recipeIngredients.Select(x => _recipeIngredientFactory.Create(x.IngredientId, x.Grams))
				.ToList();
		
		private static RecipeInfo ToDomainRecipeInfo(Entities.Recipe.RecipeInfo recipeInfo) =>
			new RecipeInfo(recipeInfo.DifficultyLevel, recipeInfo.PreparationTime, recipeInfo.ApproximateCost, recipeInfo.MealTypes);
		
	}
}