using Domain.Recipes.Events.Updated;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Updated
{
	public class RecipeUpdatedEventHandler
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeUpdatedEvent @event) => _recipeSearchInfoRepository.Update(@event.RecipeSearchInfo);
	}
}
