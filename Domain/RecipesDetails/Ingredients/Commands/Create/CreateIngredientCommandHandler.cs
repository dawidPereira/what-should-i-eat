using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Repositories;

namespace Domain.RecipesDetails.Ingredients.Commands.Create
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