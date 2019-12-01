using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, 
			IEnumerable<ICommandValidator<CreateRecipeCommand>> validators)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var recipe = Recipe.Create(
				command.Id, command.Name, command.Description, command.RecipeDetails, command.RecipeIngredients);
			
			_recipeRepository.Add(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}