﻿using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete
{
	public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<DeleteRecipeCommand>> _validators;

		public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, 
			IEnumerable<ICommandValidator<DeleteRecipeCommand>> validators)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
		}

		public Result Handle(DeleteRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var recipe = _recipeRepository.GetById(command.Id);
			
			_recipeRepository.Delete(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}