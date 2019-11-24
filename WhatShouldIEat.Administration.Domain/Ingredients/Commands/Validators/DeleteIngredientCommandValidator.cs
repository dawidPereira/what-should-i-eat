using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Validators
{
	public class DeleteIngredientCommandValidator : IValidator<DeleteIngredientCommand, Ingredient>
	{
		public Result Validate(DeleteIngredientCommand command, Ingredient ingredient)
		{
			if(ingredient == null )
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredients), 
					nameof(DeleteIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}