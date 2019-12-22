using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository,
			IEnumerable<ICommandValidator<CreateRecipeCommand>> validators,
			IEventPublisher eventPublisher)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			//TODO: Move to factory
			new Recipe(
				command.Id, command.Name, command.Description, command.RecipeDetails, command.RecipeIngredients, _eventPublisher, _recipeRepository);

			_eventPublisher.Rise(EventsQueue.RecipeCreated);
			return Result.Ok();
		}
	}
}