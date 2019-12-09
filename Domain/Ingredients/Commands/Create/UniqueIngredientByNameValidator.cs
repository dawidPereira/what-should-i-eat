using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Validators;

namespace Domain.Ingredients.Commands.Create
{
	public class UniqueIngredientByNameValidator : ICommandValidator<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UniqueIngredientByNameValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(CreateIngredientCommand command)
		{
			if(_ingredientRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Ingredient), 
					nameof(CreateIngredientCommand.Name), command.Name));
			
			return Result.Ok();
		}
	}
}