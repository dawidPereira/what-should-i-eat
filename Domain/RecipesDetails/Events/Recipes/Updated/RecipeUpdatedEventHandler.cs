using Domain.Events;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Events.Recipes.Updated
{
	public class RecipeUpdatedEventHandler : IEventHandler<RecipeUpdatedEvent>
	{
		private readonly IRecipeDetailsFactory _recipeDetailsFactory;
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public RecipeUpdatedEventHandler(IRecipeDetailsFactory recipeDetailsFactory, IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsFactory = recipeDetailsFactory;
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public void Handle(RecipeUpdatedEvent @event)
		{
			var recipeDetails = _recipeDetailsFactory.Create(@event.RecipeId);
			_recipeDetailsRepository.CreateNewOrReplaceExisting(recipeDetails);
		}
	}
}