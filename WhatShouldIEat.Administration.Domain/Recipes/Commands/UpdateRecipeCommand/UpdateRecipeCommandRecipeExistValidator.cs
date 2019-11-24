using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.UpdateIngredientCommand;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.UpdateRecipeCommand
{
	public class UpdateRecipeCommandRecipeExistValidator : ICommandValidator<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public UpdateRecipeCommandRecipeExistValidator(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public Result Validate(UpdateRecipeCommand command)
		{
			if(!_recipeRepository.ExistById(command.Id))
				Result.Fail(FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()),404);
			
			return Result.Ok(200);
		}
	}
}