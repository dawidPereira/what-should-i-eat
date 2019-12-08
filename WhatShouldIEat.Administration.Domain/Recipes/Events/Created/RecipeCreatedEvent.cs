using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries;

namespace WhatShouldIEat.Administration.Domain.Recipes.Events.Created
{
	public class RecipeCreatedEvent : IEvent
	{
		public RecipeCreatedEvent(RecipeSearchInfo recipeSearchInfo)
		{
			RecipeSearchInfo = recipeSearchInfo;
		}
		
		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}