using System;
using System.Linq;
using System.Text;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Validators
{
	public class DeleteIngredientCommandValidator : IValidator<DeleteIngredientCommand, Ingredient>
	{
		private readonly IRecipeRepository _recipeRepository;

		public DeleteIngredientCommandValidator(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public Result Validate(DeleteIngredientCommand command, Ingredient ingredient)
		{
			if(ingredient == null )
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredients), 
					nameof(DeleteIngredientCommand.Id), command.Id.ToString()));

			return CheckIfIngredientIsUsed(command.Id);
		}

		private Result CheckIfIngredientIsUsed(Guid ingredientId)
		{
			var recipesWithIngredient = _recipeRepository.GetRecipesBasicInfosByIngredientId(ingredientId);
			if (recipesWithIngredient == null) return Result.Ok();
			var message = new StringBuilder();
			message.AppendLine("Ingredient cannot be deleted. Ingredient is used in following recipes:");
			recipesWithIngredient.ForEach(x => message.AppendLine($"RecipeName: {x.Name} | RecipeId: {x.Id}."));
			return Result.Fail(message.ToString());
		}
	}
}