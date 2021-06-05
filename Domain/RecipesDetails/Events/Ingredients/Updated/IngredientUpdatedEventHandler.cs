using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Events;
using Domain.RecipesDetails.Entities;
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

		public async Task Handle(IngredientUpdatedEvent @event)
		{
			var recipesIds = await _recipeDetailsRepository.GetRecipeIdsByIngredientId(@event.IngredientId);
			var recipeDetailsCollection = new List<RecipeDetails>();
			foreach (var recipesId in recipesIds)
			{
				var recipeDetails = await _recipeDetailsFactory.Create(recipesId);
				recipeDetailsCollection.Add(recipeDetails);

			}
			await _recipeDetailsRepository.CreateNewOrReplaceExistingRange(recipeDetailsCollection);
		}
	}
}
