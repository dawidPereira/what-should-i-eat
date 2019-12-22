using Domain.Common.Mediators.Events;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Events.Deleted
{
	public class RecipeDeletedEventHandler : IEventHandler<RecipeDeletedEvent>
	{
		private readonly IRecipeSearchInfoRepository _recipeSearchInfoRepository;

		public RecipeDeletedEventHandler(IRecipeSearchInfoRepository recipeSearchInfoRepository) => 
			_recipeSearchInfoRepository = recipeSearchInfoRepository;

		public void Handle(RecipeDeletedEvent @event) => _recipeSearchInfoRepository.Remove(@event.Id.ToString());
	}
}