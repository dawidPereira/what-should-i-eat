using Domain.Common.Events;
using Domain.Ingredients.Events.Updated;
using Domain.Recipes.Repositories;
using Hangfire;

namespace Infrastructure.Events.Ingredients.Updated
{
	public class RecipeUpdatedEventHandler : IEventHandler<IngredientUpdatedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository)
		{
			_recipeSearchInfoRepository = recipeSearchInfoRepository;
		}

		public void Handle(IngredientUpdatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoRepository.UpdateRecipeSearchInfoByIngredientId(@event.Id));
	}
}