using Domain.Common.Mediators.Events;
using Domain.Recipes.SearchInfos;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEvent : IEvent<RecipeCreatedEvent>
	{
		public RecipeCreatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}