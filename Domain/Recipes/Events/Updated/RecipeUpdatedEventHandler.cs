using Domain.Recipes.Repositories;

namespace Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEventHandler
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeUpdatedEvent @event) => _recipeSearchInfoRepository.Update(@event.RecipeSearchInfo);
	}
}
