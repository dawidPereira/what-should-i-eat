using System.Threading.Tasks;
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

		public async Task Handle(RecipeDeletedEvent @event) => await _recipeDetailsRepository.RemoveById(@event.RecipeId);
	}
}
