using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Commands.Create;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEnumerable<ICommandValidator<CreateIngredientCommand>> _validators;
		private readonly IIngredientFactory _ingredientFactory;
		private readonly IEventPublisher _eventPublisher;

		public CreateIngredientCommandHandler(
			IIngredientRepository ingredientRepository, 
			IIngredientFactory ingredientFactory, 
			IEventPublisher eventPublisher,
			IEnumerable<ICommandValidator<CreateIngredientCommand>> validators)
		{
			_ingredientRepository = ingredientRepository;
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
				command.Id, command.Name, command.Allergens, command.Requirements, command.Shares, _eventPublisher);
			_eventPublisher.Rise(EventsQueue.IngredientCreated);
			return Result.Ok();
		}
	}
}