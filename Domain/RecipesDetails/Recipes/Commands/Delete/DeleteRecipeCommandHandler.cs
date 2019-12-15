using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Recipes.Events.Deleted;
using Domain.RecipesDetails.Recipes.Repositories;

namespace Domain.RecipesDetails.Recipes.Commands.Delete
{
	public class DeleteRecipeCommandHandler : ICommandHandler<DeleteRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<DeleteRecipeCommand>> _validators;

		public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository,
			IEnumerable<ICommandValidator<DeleteRecipeCommand>> validators,
			IEventPublisher eventPublisher)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(DeleteRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var recipe = _recipeRepository.GetById(command.Id);

			_recipeRepository.Delete(recipe);
			_recipeRepository.Commit();
			_eventPublisher.Publish(new RecipeDeletedEvent(command.Id));
			return Result.Ok();
		}
	}
}