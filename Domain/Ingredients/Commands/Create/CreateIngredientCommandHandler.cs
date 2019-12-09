using System.Collections.Generic;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Domain.Mediators.Command;
using Domain.Mediators.Validators;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<CreateIngredientCommand>> _validators;

		public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository, 
			IEnumerable<ICommandValidator<CreateIngredientCommand>> validators)
		{
			_ingredientRepository = ingredientRepository;
			_validators = validators;
		}

		public Result Handle(CreateIngredientCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var ingredient = Ingredient.Create(
				command.Id, command.Name, command.Allergens, command.Requirements, command.MacroNutrientsParticipation);

			_ingredientRepository.Add(ingredient);
			_ingredientRepository.Commit();
			return Result.Ok();
		}
	}
}