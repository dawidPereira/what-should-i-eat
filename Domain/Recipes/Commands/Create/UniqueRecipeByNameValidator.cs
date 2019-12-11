using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Create
{
	public class UniqueRecipeByNameValidator : ICommandValidator<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public UniqueRecipeByNameValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(CreateRecipeCommand command)
		{
			if (_recipeRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));

			return Result.Ok();
		}
	}
}