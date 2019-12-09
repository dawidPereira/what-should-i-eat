using System.Collections.Generic;
using Domain.Common.Validators;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Command;

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
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var ingredient = _ingredientRepository.GetById(command.Id);

			_ingredientRepository.Remove(ingredient);
			_ingredientRepository.Commit();
			return  Result.Ok();
		}
	}
}