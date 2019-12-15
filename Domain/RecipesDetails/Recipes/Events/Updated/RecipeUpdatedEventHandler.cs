using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Events.Updated
{
	public class RecipeUpdatedEventHandler
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeUpdatedEvent @event) => _recipeSearchInfoRepository.Add(@event.RecipeSearchInfo);
	}
}