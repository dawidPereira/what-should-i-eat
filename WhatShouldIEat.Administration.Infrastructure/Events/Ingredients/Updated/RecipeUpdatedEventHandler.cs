using Hangfire;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Ingredients.Events.Updated;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Infrastructure.Events.Ingredients.Updated
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