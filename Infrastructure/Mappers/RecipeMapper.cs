using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Events;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Infrastructure.Mappers
{
	public class RecipeMapper
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly RecipeIngredient.RecipeIngredientFactory _recipeIngredientFactory;

		public RecipeMapper(IRecipeRepository recipeRepository, IEventPublisher eventPublisher, IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_eventPublisher = eventPublisher;
			_recipeIngredientFactory = new RecipeIngredient.RecipeIngredientFactory(ingredientRepository);
		}

		public Recipe ToDomainRecipe(Entities.Recipe.Recipe recipe)
		{
			var recipeFactory = new Recipe.RecipeFactory(_recipeRepository, _eventPublisher);
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