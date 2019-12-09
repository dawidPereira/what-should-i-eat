using Domain.Common.Events;
using Domain.Recipes.Events.Deleted;
using Domain.Recipes.Repositories;
using Hangfire;

namespace Infrastructure.Events.Recipes.Deleted
{
	public class RecipeDeletedEventHandler : IEventHandler<RecipeDeletedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeDeletedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository)
		{
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
		}

		public void Handle(RecipeDeletedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoRepository.Remove(@event.Id.ToString()));
	}
}