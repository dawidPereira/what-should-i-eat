using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.CreateIngredientCommand
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<CreateIngredientCommand>> _validators;

		public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository, 
			IEnumerable<ICommandValidator<CreateIngredientCommand>> validators)
		{
			_ingredientRepository = ingredientRepository;
			_validators = validators;
		}

		public Result Handle(CreateIngredientCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var ingredient = Ingredient.Create(command);

			_ingredientRepository.Add(ingredient);
			_ingredientRepository.Commit();
			return Result.Ok(201);
		}
	}
}