using Domain.Recipes.Events.Updated;
using Domain.Recipes.Repositories;
using Hangfire;

namespace Infrastructure.Events.Recipes.Updated
{
	public class RecipeUpdatedEventHandler
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository)
		{
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
		}

		public void Handle(RecipeUpdatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoRepository.Update(@event.RecipeSearchInfo));
	}
}
