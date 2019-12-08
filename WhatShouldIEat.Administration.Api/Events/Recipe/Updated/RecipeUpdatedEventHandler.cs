using Hangfire;
using WhatShouldIEat.Administration.Api.Cache;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Updated;

namespace WhatShouldIEat.Administration.Api.Events.Recipe.Updated
{
	public class RecipeUpdatedEventHandler
	{
		private readonly IRecipeSearchInfoCacheInvalidator _recipeSearchInfoCacheInvalidator;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoCacheInvalidator recipeSearchInfoCacheInvalidator)
		{
			_recipeSearchInfoCacheInvalidator = recipeSearchInfoCacheInvalidator;
		}

		public void Handle(RecipeUpdatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoCacheInvalidator.Update(@event.RecipeSearchInfo));
	}
}
