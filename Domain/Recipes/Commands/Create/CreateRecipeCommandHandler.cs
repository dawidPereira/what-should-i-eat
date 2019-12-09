using System.Collections.Generic;
using Domain.Common.Command;
using Domain.Common.Events;
using Domain.Common.Validators;
using Domain.Common.ValueObjects;
using Domain.Recipes.Entities;
using Domain.Recipes.Events.Created;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;
		private readonly IEventPublisher _eventPublisher;

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
			
			var recipe = Recipe.Create(
				command.Id, command.Name, command.Description, command.RecipeDetails, command.RecipeIngredients);
			
			_recipeRepository.Add(recipe);
			_recipeRepository.Commit();
			_eventPublisher.Publish(new RecipeCreatedEvent(recipe.CalculateSearchInfo()));
			return Result.Ok();
		}
	}
}