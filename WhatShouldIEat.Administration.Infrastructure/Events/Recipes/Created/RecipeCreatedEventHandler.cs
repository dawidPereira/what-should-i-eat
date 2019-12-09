using Hangfire;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Created;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Infrastructure.Events.Recipes.Created
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