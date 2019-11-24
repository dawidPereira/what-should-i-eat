using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Handlers
{
	public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<UpdateRecipeCommand>> _validators;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, 
			IEnumerable<ICommandValidator<UpdateRecipeCommand>> validators)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
		}

		public Result Handle(UpdateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var recipe = _recipeRepository.GetById(command.Id);
			
			recipe.Update(command);
			_recipeRepository.Update(recipe);
			_recipeRepository.Commit();
			return Result.Ok(200);
		}
	}
}