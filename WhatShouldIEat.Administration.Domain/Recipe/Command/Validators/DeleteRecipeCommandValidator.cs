using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Validators
{
	using Recipe = Entities.Recipe.Recipe;
	
	public class DeleteRecipeCommandValidator 
	{
		public Result Validate(Entities.Recipe.Recipe recipe, DeleteRecipeCommand command)
		{
			if(recipe == null )
				Exceptions<Recipe>.ThrowNotFoundException(nameof(command.Id), command.Id.ToString());
			
			return Result.Ok();
		}
	}
}