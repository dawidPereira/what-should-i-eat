using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Delete
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
			recipe.Delete();
			return Result.Ok();
		}
	}
}