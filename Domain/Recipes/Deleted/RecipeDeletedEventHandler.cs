using Domain.Mediators.Events;
using Domain.Recipes.Events.Deleted;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Deleted
{
	public class RecipeDeletedEventHandler : IEventHandler<RecipeDeletedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeDeletedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeDeletedEvent @event) => _recipeSearchInfoRepository.Remove(@event.Id.ToString());
	}
}