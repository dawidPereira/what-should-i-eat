using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Handlers
{
	public class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<DeleteIngredientCommand>> _validators;

		public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository, 
			IEnumerable<ICommandValidator<DeleteIngredientCommand>> validators)
		{
			_ingredientRepository = ingredientRepository;
			_validators = validators;
		}

		public Result Handle(DeleteIngredientCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var ingredient = _ingredientRepository.GetById(command.Id);

			_ingredientRepository.Remove(ingredient);
			_ingredientRepository.Commit();
			return  Result.Ok(200);
		}
	}
}