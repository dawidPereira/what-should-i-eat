using Domain.Events;
using Domain.RecipesDetails.RecipeDetailsFactories;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Events.Recipes.Created
{
	public class RecipeCreatedEventHandler : IEventHandler<RecipeCreatedEvent>
	{
		private readonly IRecipeDetailsFactory _recipeDetailsFactory;
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public RecipeCreatedEventHandler(IRecipeDetailsFactory recipeDetailsFactory, IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsFactory = recipeDetailsFactory;
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public void Handle(RecipeCreatedEvent @event)
		{
			var recipeDetails = _recipeDetailsFactory.Create(@event.RecipeId);
			_recipeDetailsRepository.CreateNewOrReplaceExisting(recipeDetails);
		}
	}
}