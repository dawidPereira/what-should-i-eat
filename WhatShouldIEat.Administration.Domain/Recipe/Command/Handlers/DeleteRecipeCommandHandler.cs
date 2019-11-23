using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Command.Validators;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly DeleteRecipeCommandValidator _validator;

		public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_validator = new DeleteRecipeCommandValidator();
		}

		public Result Handle(DeleteRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			var validationResult = _validator.Validate(recipe, command);
			if (validationResult.IsFailure)
				return validationResult;
			
			_recipeRepository.Delete(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}