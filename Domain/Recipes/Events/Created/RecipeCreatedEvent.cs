using Domain.Common.Mediators.Events;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEvent : IEvent
	{
		public RecipeCreatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}