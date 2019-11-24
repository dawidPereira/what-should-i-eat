﻿using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Validators
{
	public class DeleteIngredientCommandIngredientExistValidator : ICommandValidator<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public DeleteIngredientCommandIngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(DeleteIngredientCommand command)
		{
			if(!_ingredientRepository.ExistById(command.Id))
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredients), 
					nameof(DeleteIngredientCommand.Id), command.Id.ToString()), 404);
			
			return Result.Ok(200);
		}
	}
}