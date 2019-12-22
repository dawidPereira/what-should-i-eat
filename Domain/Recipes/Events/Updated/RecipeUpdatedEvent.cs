using Domain.Recipes.SearchInfos;

namespace Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEvent : IEvent
	{
		public RecipeUpdatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}