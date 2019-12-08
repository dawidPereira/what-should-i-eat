using Hangfire;
using WhatShouldIEat.Administration.Api.Cache;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Created;

namespace WhatShouldIEat.Administration.Api.Events.Recipes.Created
{
	public class RecipeCreatedEventHandler : IEventHandler<RecipeCreatedEvent>
	{
		private readonly IRecipeSearchInfoCacheInvalidator _recipeSearchInfoCacheInvalidator;

		public RecipeCreatedEventHandler(IRecipeSearchInfoCacheInvalidator recipeSearchInfoCacheInvalidator)
		{
			_recipeSearchInfoCacheInvalidator = recipeSearchInfoCacheInvalidator;
		}

		public void Handle(RecipeCreatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoCacheInvalidator.Update(@event.RecipeSearchInfo));
	}
}