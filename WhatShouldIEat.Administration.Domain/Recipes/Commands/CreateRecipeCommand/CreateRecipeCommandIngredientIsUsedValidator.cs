using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.UpdateIngredientCommand;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.CreateRecipeCommand
{
	public class CreateRecipeCommandIngredientIsUsedValidator : ICommandValidator<CreateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IRecipeRepository _recipeRepository;

		public CreateRecipeCommandIngredientIsUsedValidator(IIngredientRepository ingredientRepository,
			IRecipeRepository recipeRepository)
		{
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
		}

		public Result Validate(CreateRecipeCommand command)
		{
			foreach (var commandRecipeIngredient in command.RecipeIngredients)
			{
				var exist = _ingredientRepository.ExistById(commandRecipeIngredient.IngredientId);
				if (!exist)
					Result.Fail(FailMessages.DoesNotExist(nameof(Ingredient), 
						nameof(UpdateIngredientCommand.Id), command.Id.ToString()),404);
			}
			
			return Result.Ok(200);
		}
	}
}