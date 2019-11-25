using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create
{
	public class UniqueIngredientByNameValidator : ICommandValidator<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UniqueIngredientByNameValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(CreateIngredientCommand command)
		{
			if(_ingredientRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Ingredient), 
					nameof(CreateIngredientCommand.Name), command.Name));
			
			return Result.Ok();
		}
	}
}