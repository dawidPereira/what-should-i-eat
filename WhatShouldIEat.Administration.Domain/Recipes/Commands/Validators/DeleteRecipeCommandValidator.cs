using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators
{
	public class DeleteRecipeCommandValidator 
	{
		public Result Validate(Recipe recipe, DeleteRecipeCommand command)
		{
			if(recipe == null )
				Exceptions<Recipe>.ThrowNotFoundException(nameof(command.Id), command.Id.ToString());
			
			return Result.Ok();
		}
	}
}