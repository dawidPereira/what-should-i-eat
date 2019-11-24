using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators
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