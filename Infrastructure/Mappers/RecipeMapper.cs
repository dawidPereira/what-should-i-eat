using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Infrastructure.Mappers
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
			return recipeFactory.Create(recipe.Id,
				recipe.Name,
				recipe.Description,
				recipe.RecipeInfo,
				GetRecipeIngredients(recipe.RecipeIngredients));
		}

		private IEnumerable<RecipeIngredient> GetRecipeIngredients(IEnumerable<Entities.Recipe.RecipeIngredient> recipeIngredients) =>
			recipeIngredients.Select(x => _recipeIngredientFactory.Create(x.IngredientId, x.Grams))
				.ToList();
	}
}