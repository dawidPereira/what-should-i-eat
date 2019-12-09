using Domain.Common.Events;
using Domain.Recipes.Events.Created;
using Domain.Recipes.Repositories;
using Hangfire;

namespace Infrastructure.Events.Recipes.Created
{
	public class RecipeCreatedEventHandler : IEventHandler<RecipeCreatedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeCreatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository)
		{
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
		}

		public void Handle(RecipeCreatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoRepository.Update(@event.RecipeSearchInfo));
	}
}