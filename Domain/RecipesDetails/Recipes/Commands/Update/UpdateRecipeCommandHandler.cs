using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Commands.Update
{
	public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<UpdateRecipeCommand>> _validators;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository,
			IEnumerable<ICommandValidator<UpdateRecipeCommand>> validators,
			IEventPublisher eventPublisher)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(UpdateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			var recipe = _recipeRepository.GetById(command.Id);

			recipe.Update(command.Name, command.Description, command.RecipeDetails, command.RecipeIngredients);
			_eventPublisher.Rise(EventsQueue.RecipeUpdated);
			return Result.Ok();
		}
	}
}