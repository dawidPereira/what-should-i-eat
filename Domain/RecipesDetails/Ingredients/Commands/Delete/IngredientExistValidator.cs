using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Ingredients.Repositories;

namespace Domain.RecipesDetails.Ingredients.Commands.Delete
{
	public class IngredientExistValidator : ICommandValidator<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(DeleteIngredientCommand command)
		{
			if (!_ingredientRepository.ExistById(command.Id))
				return Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredients),
					nameof(DeleteIngredientCommand.Id), command.Id.ToString()));

			return Result.Ok();
		}
	}
}