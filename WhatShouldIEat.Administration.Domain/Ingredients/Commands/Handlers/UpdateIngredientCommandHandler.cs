﻿using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Handlers
{
	public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IValidator<UpdateIngredientCommand, Ingredient> _validator;

		public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository, IValidator<UpdateIngredientCommand, Ingredient> validator)
		{
			_ingredientRepository = ingredientRepository;
			_validator = validator;
		}

		public Result Handle(UpdateIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);

			var validationResult = _validator.Validate(command, ingredient);
			if (validationResult.IsFailure)
				return validationResult;
			
			ingredient.Update(command);
			_ingredientRepository.Update(ingredient);
			_ingredientRepository.Commit();
			
			return Result.Ok();
		}
	}
}