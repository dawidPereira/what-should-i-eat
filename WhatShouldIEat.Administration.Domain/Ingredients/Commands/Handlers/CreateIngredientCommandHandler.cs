using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Handlers
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IValidator<CreateIngredientCommand> _validator;

		public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository, IValidator<CreateIngredientCommand> validator)
		{
			_ingredientRepository = ingredientRepository;
			_validator = validator;
		}

		public Result Handle(CreateIngredientCommand command)
		{
			var validationResult = _validator.Validate(command);
			if (validationResult.IsFailure)
				return validationResult;

			var ingredient = Ingredient.Create(command);

			_ingredientRepository.Add(ingredient);
			_ingredientRepository.Commit();
			return Result.Ok();
		}
	}
}