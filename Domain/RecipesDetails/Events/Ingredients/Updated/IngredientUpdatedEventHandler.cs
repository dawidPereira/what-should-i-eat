using System.Linq;
using Domain.Events;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Events.Ingredients.Updated
{
	public class IngredientUpdatedEventHandler : IEventHandler<IngredientUpdatedEvent>
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;
		private readonly IRecipeDetailsFactory _recipeDetailsFactory;

		public IngredientUpdatedEventHandler(IRecipeDetailsRepository recipeDetailsRepository, IRecipeDetailsFactory recipeDetailsFactory)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
			_recipeDetailsFactory = recipeDetailsFactory;
		}

		public void Handle(IngredientUpdatedEvent @event)
		{
			var recipesIds = _recipeDetailsRepository.GetRecipeIdsByIngredientId(@event.IngredientId);
			var recipeDetailsCollection = recipesIds.Select(_recipeDetailsFactory.Create);
			_recipeDetailsRepository.CreateNewOrUpdateExistingRange(recipeDetailsCollection);
		}
	}
}