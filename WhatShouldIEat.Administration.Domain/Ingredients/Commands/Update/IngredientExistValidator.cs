﻿using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update
{
	public class IngredientExistValidator : ICommandValidator<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(UpdateIngredientCommand command)
		{
			if(!_ingredientRepository.ExistById(command.Id))
				return Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}