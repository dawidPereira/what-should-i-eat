using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Recipes.Factories;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeFactory _recipeFactory;
		private readonly IRecipeIngredientFactory _recipeIngredientFactory;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;

		public CreateRecipeCommandHandler(
			IEnumerable<ICommandValidator<CreateRecipeCommand>> validators,
			IEventPublisher eventPublisher, 
			IRecipeFactory recipeFactory, 
			IRecipeIngredientFactory recipeIngredientFactory)
		{
			_validators = validators;
			_eventPublisher = eventPublisher;
			_recipeFactory = recipeFactory;
			_recipeIngredientFactory = recipeIngredientFactory;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var recipeIngredients = command.RecipeIngredients.Select(x =>
				_recipeIngredientFactory.Create(x.IngredientId, x.Grams));

			_recipeFactory.Create(command.Id,
				command.Name,
				command.Description,
				command.RecipeInfo,
				recipeIngredients);

			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}