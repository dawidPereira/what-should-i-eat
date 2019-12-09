using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Validators;

namespace Domain.Ingredients.Commands.Update
{
	public class UniqueIngredientNameValidator : ICommandValidator<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UniqueIngredientNameValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(UpdateIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);
			if (command.Name.Equals(ingredient.Name)) return Result.Ok();
			
			if (_ingredientRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Name), command.Name));

			return Result.Ok();
		}
	}
}