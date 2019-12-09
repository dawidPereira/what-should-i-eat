using Hangfire;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Updated;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Infrastructure.Events.Recipes.Updated
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
