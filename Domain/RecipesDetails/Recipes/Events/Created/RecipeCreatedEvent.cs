using Domain.Common.Mediators.Events;
using Domain.RecipesDetails.Recipes.SearchInfos;

namespace Domain.RecipesDetails.Recipes.Events.Created
{
	public class RecipeCreatedEvent : IEvent<RecipeCreatedEvent>
	{
		public RecipeCreatedEvent(RecipeSearchInfo recipeSearchInfo) => 
			RecipeSearchInfo = recipeSearchInfo;

		public RecipeSearchInfo RecipeSearchInfo { get; }
	}
}