using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Commands.Update
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

			ingredient.Update(command.Name, command.Allergens, command.Requirements, command.Shares);
			_ingredientRepository.Commit();
			_eventPublisher.Rise(EventsQueue.IngredientUpdated);
			return Result.Ok();
		}
	}
}