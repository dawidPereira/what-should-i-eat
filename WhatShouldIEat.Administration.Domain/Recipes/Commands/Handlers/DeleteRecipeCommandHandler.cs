using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Handlers
{
	public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IValidator<DeleteRecipeCommand, Recipe> _validator;

		public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, IValidator<DeleteRecipeCommand, Recipe> validator)
		{
			_recipeRepository = recipeRepository;
			_validator = validator;
		}

		public Result Handle(DeleteRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			var validationResult = _validator.Validate(command, recipe);
			if (validationResult.IsFailure)
				return validationResult;
			
			_recipeRepository.Delete(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}