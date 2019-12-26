using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Recipes.Factories;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeFactory _recipeFactory;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository,
			IEnumerable<ICommandValidator<CreateRecipeCommand>> validators,
			IEventPublisher eventPublisher, 
			IRecipeFactory recipeFactory)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
			_recipeFactory = recipeFactory;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			_recipeFactory.Create(command.Id,
				command.Name,
				command.Description,
				command.RecipeInfo,
				command.RecipeIngredients,
				_eventPublisher,
				_recipeRepository);

			_eventPublisher.Rise(EventsQueue.RecipeCreated);
			return Result.Ok();
		}
	}
}