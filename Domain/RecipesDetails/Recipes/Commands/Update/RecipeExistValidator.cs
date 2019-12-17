using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Commands.Update
{
	public class UpdateRecipeCommandRecipeExistValidator : ICommandValidator<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public UpdateRecipeCommandRecipeExistValidator(IRecipeRepository recipeRepository)
		{
			_recipeRepository = recipeRepository;
		}

		public Result Validate(UpdateRecipeCommand command)
		{
			if (!_recipeRepository.ExistById(command.Id))
				Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient),
					nameof(UpdateRecipeCommand.Id), command.Id.ToString()));
			//TODO: Fix  bad ID
			return Result.Ok();
		}
	}
}