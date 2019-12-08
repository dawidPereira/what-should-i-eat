using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries;

namespace WhatShouldIEat.Administration.Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEvent : IEvent
	{
		public RecipeUpdatedEvent(RecipeSearchInfo recipeSearchInfo)
		{
			RecipeSearchInfo = recipeSearchInfo;
		}
		
		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}