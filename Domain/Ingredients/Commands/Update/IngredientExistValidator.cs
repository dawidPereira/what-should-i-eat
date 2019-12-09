using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Commands.Update
{
	public class IngredientExistValidator : ICommandValidator<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(UpdateIngredientCommand command)
		{
			if(!_ingredientRepository.ExistById(command.Id))
				return Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}