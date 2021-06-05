using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Ingredients.Entities;
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

		public async Task<Result> Handle(UpdateIngredientCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure) return validationResult;
			}

			var ingredient = _ingredientRepository.GetById(command.Id);
			if (ingredient == null)
				return Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient),
					nameof(UpdateIngredientCommand.Id), command.Id.ToString()));

			ingredient.Update(command.Name, command.Allergens, command.Requirements, command.Shares);
			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}
