using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Validators
{
	public class UpdateIngredientCommandValidator : IValidator<UpdateIngredientCommand, Ingredient>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UpdateIngredientCommandValidator(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public Result Validate(UpdateIngredientCommand command, Ingredient ingredient)
		{
			if(ingredient == null)
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));

			if (!command.Name.Equals(ingredient.Name))
				if (_ingredientRepository.ExistByName(command.Name))
					return Result.Fail(FailMessages.AlreadyExist(nameof(Ingredient), 
						nameof(UpdateIngredientCommand.Name), command.Name));
			
			return Result.Ok();
		}
	}
}