using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Entities;
using Domain.Mediators.Validators;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Update
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
			if(!_recipeRepository.ExistById(command.Id))
				Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}