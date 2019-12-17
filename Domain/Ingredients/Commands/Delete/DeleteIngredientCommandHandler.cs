using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<DeleteIngredientCommand>> _validators;

		public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository,
			IEnumerable<ICommandValidator<DeleteIngredientCommand>> validators)
		{
			_ingredientRepository = ingredientRepository;
			_validators = validators;
		}

		public Result Handle(DeleteIngredientCommand command)
		{
			//TODO: Add validation if ingredient is used or rise event for notify admins and hide recipes with this ingredient.
			var ingredient = _ingredientRepository.GetById(command.Id);
			if (ingredient == null) 
				return Result.Fail(ResultCode.NotFound, $"Ingredient with {command.Id}, does not exist");
			ingredient.Delete();
			return Result.Ok();
		}
	}
}