using Domain.Mediators.Events;
using Domain.Recipes.Repositories;

namespace Domain.Ingredients.Events.Updated
{
	public class RecipeUpdatedEventHandler : IEventHandler<IngredientUpdatedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeUpdatedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(IngredientUpdatedEvent @event) => 
			_recipeSearchInfoRepository.UpdateRecipeSearchInfoByIngredientId(@event.Id);
	}
}