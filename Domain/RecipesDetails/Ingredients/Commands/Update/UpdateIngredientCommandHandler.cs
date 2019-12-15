using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Ingredients.Events.Updated;
using Domain.RecipesDetails.Ingredients.Repositories;

namespace Domain.RecipesDetails.Ingredients.Commands.Update
{
	public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<UpdateIngredientCommand>> _validators;

		public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository,
			IEnumerable<ICommandValidator<UpdateIngredientCommand>> validators,
			IEventPublisher eventPublisher)
		{
			_ingredientRepository = ingredientRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(UpdateIngredientCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var ingredient = _ingredientRepository.GetById(command.Id);

			ingredient.Update(command);
			_ingredientRepository.Commit();
			_eventPublisher.Publish(new IngredientUpdatedEvent(command.Id));
			return Result.Ok();
		}
	}
}