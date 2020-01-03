using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Ingredients.Factories;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IEnumerable<ICommandValidator<CreateIngredientCommand>> _validators;
		private readonly IIngredientFactory _ingredientFactory;
		private readonly IEventPublisher _eventPublisher;

		public CreateIngredientCommandHandler(
			IIngredientFactory ingredientFactory, 
			IEventPublisher eventPublisher,
			IEnumerable<ICommandValidator<CreateIngredientCommand>> validators)
		{
			_ingredientFactory = ingredientFactory;
			_eventPublisher = eventPublisher;
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
			_ingredientFactory.Create(
				command.Id, command.Name, command.Allergens, command.Requirements, command.Shares);
			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}