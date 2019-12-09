using Domain.Common.Events;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Events.Created
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