using Hangfire;
using WhatShouldIEat.Administration.Api.Cache;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Deleted;

namespace WhatShouldIEat.Administration.Api.Events.Recipes.Deleted
{
	public class RecipeDeletedEventHandler : IEventHandler<RecipeDeletedEvent>
	{
		private readonly IRecipeSearchInfoCacheInvalidator _recipeSearchInfoCacheInvalidator;

		public RecipeDeletedEventHandler(IRecipeSearchInfoCacheInvalidator recipeSearchInfoCacheInvalidator)
		{
			_recipeSearchInfoCacheInvalidator = recipeSearchInfoCacheInvalidator;
		}

		public void Handle(RecipeDeletedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoCacheInvalidator.Remove(@event.Id.ToString()));
	}
}