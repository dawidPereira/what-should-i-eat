﻿using System.Threading.Tasks;
using Domain.Events;
using Domain.RecipesDetails.Repositories;

namespace Domain.RecipesDetails.Events.Ingredients.Deleted
{
	public class IngredientDeletedEventHandler : IEventHandler<IngredientDeletedEvent>
	{
		private readonly IRecipeDetailsRepository _recipeDetailsRepository;

		public IngredientDeletedEventHandler(IRecipeDetailsRepository recipeDetailsRepository)
		{
			_recipeDetailsRepository = recipeDetailsRepository;
		}

		public async Task Handle(IngredientDeletedEvent @event)
		{
			//TODO : Check if ingredient is used in any recipe.
			//TODO : CreateNewOrUpdateExisting possibility to mark ingredient us unpublished.
			//TODO: CreateNewOrUpdateExisting information about recipe creator.
			//TODO: Send email to recipe creator with information about removed ingredient.
		}
	}
}
