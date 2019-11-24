using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators
{
	public class DeleteRecipeCommandValidator : IValidator<DeleteRecipeCommand, Recipe>
	{
		public Result Validate(DeleteRecipeCommand command, Recipe recipe)
		{
			if(recipe == null )
				Exceptions<Recipe>.ThrowNotFoundException(nameof(command.Id), command.Id.ToString());
			
			return Result.Ok();
		}
	}
}