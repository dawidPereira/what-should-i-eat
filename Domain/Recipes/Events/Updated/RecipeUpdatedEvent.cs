using Domain.Common.Mediators.Events;
using Domain.Recipes.Queries.SearchInfoQueries;

namespace Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEvent : IEvent
	{
		public RecipeUpdatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}