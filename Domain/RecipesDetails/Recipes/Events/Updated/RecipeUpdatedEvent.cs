using Domain.Common.Mediators.Events;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Events.Updated
{
	public class RecipeUpdatedEvent : IEvent
	{
		public RecipeUpdatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}