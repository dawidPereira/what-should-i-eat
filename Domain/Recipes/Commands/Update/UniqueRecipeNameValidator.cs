using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Update
{
	public class UniqueRecipeNameValidator : ICommandValidator<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public UniqueRecipeNameValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(UpdateRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			if (recipe.Name != command.Name && _recipeRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));

			return Result.Ok();
		}
	}
}