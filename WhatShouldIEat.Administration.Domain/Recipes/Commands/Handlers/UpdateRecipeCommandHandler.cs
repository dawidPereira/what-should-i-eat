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
		private readonly IValidator<UpdateRecipeCommand, Recipe> _validator;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, IValidator<UpdateRecipeCommand, Recipe> validator)
		{
			_recipeRepository = recipeRepository;
			_validator = validator;
		}

		public Result Handle(UpdateRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			var validationResult = _validator.Validate(command, recipe);
			if (validationResult.IsFailure)
				return validationResult;

			recipe.Update(command);
			_recipeRepository.Update(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}