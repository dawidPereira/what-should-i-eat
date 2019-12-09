using Hangfire;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Deleted;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Infrastructure.Events.Recipes.Deleted
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