using System.Linq;
using Domain.Common.Mediators.Events;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Ingredients.Events.Updated
{
	public class RecipeUpdatedEventHandler : IEventHandler<IngredientUpdatedEvent>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;


		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository,
			IRecipeRepository recipeRepository)
		{
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
			_recipeRepository = recipeRepository;
		}

		public void Handle(IngredientUpdatedEvent @event)
		{
			var affectedRecipes = _recipeRepository
				.GetRecipesByIngredientId(@event.Id)
				.Select(x => x.CalculateSearchInfo())
				.ToList();

			_recipeSearchInfoRepository.AddRange(affectedRecipes);
		}
	}
}