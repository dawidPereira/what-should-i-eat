﻿using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Update
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
				Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}