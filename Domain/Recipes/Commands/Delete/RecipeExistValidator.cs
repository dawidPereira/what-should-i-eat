using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Mediators.Validators;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Delete
{
	public class RecipeExistByIdValidator : ICommandValidator<DeleteRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public RecipeExistByIdValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(DeleteRecipeCommand command)
		{
			if(!_recipeRepository.ExistById(command.Id))
				Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Recipe), 
					nameof(DeleteRecipeCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}