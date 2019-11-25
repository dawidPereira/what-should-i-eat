﻿using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete
{
	public class IngredientExistValidator : ICommandValidator<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(DeleteIngredientCommand command)
		{
			if(!_ingredientRepository.ExistById(command.Id))
				return Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredients), 
					nameof(DeleteIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}