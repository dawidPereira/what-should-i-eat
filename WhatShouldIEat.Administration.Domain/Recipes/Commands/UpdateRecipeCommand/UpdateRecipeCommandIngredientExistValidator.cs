using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.UpdateIngredientCommand;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.UpdateRecipeCommand
{
	public class UpdateRecipeCommandIngredientExistValidator : ICommandValidator<UpdateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UpdateRecipeCommandIngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(UpdateRecipeCommand command)
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