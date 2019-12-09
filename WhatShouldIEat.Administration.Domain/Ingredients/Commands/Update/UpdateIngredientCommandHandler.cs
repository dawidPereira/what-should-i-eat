using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Events.Updated;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update
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