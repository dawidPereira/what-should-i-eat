using System.Threading.Tasks;
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

		public async Task Handle(RecipeUpdatedEvent @event)
		{
			var recipeDetails = await _recipeDetailsFactory.Create(@event.RecipeId);
			await _recipeDetailsRepository.CreateNewOrReplaceExisting(recipeDetails);
		}
	}
}
