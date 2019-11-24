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
		private readonly IValidator<DeleteIngredientCommand, Ingredient> _validator;

		public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository, IValidator<DeleteIngredientCommand, Ingredient> validator)
		{
			_ingredientRepository = ingredientRepository;
			_validator = validator;
		}

		public Result Handle(DeleteIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);

			var validationResult = _validator.Validate(command, ingredient);
			if (validationResult.IsFailure)
				return validationResult;

			_ingredientRepository.Remove(ingredient);
			_ingredientRepository.Commit();
			return  Result.Ok();
		}
	}
}