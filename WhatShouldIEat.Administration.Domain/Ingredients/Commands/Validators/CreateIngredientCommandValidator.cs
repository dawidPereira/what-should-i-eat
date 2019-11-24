﻿using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Validators
{
	public class CreateIngredientCommandValidator : IValidator<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public CreateIngredientCommandValidator(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public Result Validate(CreateIngredientCommand command)
		{
			if(_ingredientRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Ingredient), 
					nameof(CreateIngredientCommand.Name), command.Name));
			
			return Result.Ok();
		}
	}
}