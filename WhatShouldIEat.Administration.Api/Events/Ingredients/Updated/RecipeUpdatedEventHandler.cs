using Hangfire;
using WhatShouldIEat.Administration.Api.Cache;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Ingredients.Events.Updated;

namespace WhatShouldIEat.Administration.Api.Events.Ingredients.Updated
{
	public class RecipeUpdatedEventHandler : IEventHandler<IngredientUpdatedEvent>
	{
		private readonly IRecipeSearchInfoCacheInvalidator _recipeSearchInfoCacheInvalidator;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoCacheInvalidator recipeSearchInfoCacheInvalidator)
		{
			_recipeSearchInfoCacheInvalidator = recipeSearchInfoCacheInvalidator;
		}

		public void Handle(IngredientUpdatedEvent @event) => BackgroundJob.Enqueue(() => 
			_recipeSearchInfoCacheInvalidator.UpdateRecipeSearchInfoByIngredientId(@event.Id));
	}
}