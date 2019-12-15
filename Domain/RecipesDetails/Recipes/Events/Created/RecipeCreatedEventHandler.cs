using Domain.Common.Mediators.Events;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Events.Created
{
	public class RecipeCreatedEventHandler : IEventHandler<RecipeCreatedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeCreatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeCreatedEvent @event) => _recipeSearchInfoRepository.Add(@event.RecipeSearchInfo);
	}
}