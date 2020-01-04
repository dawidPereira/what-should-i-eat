using Domain.Events;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Events.Recipes.Deleted
{
	public class RecipeDeletedEventHandler : IEventHandler<RecipeDeletedEvent>
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public RecipeDeletedEventHandler(IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public void Handle(RecipeDeletedEvent @event) => _recipeDetailsRepository.RemoveById(@event.RecipeId);
	}
}