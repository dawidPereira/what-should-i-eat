using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Recipes.Factories;
using Domain.Recipes.Repositories;

namespace Domain.Recipes.Commands.Update
{
	public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeIngredientFactory _recipeIngredientFactory;
		private readonly IEnumerable<ICommandValidator<UpdateRecipeCommand>> _validators;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository,
			IEnumerable<ICommandValidator<UpdateRecipeCommand>> validators,
			IEventPublisher eventPublisher, IRecipeIngredientFactory recipeIngredientFactory)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_eventPublisher = eventPublisher;
			_recipeIngredientFactory = recipeIngredientFactory;
		}

		public async Task<Result> Handle(UpdateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			var recipe = _recipeRepository.GetById(command.Id);
			if(recipe == null)
				return Result.Fail(ResultCode.NotFound, $"Recipe with Id{command.Id} does not exist;");

			var recipeIngredients = command.RecipeIngredients.Select(x =>
				_recipeIngredientFactory.Create(x.IngredientId, x.Grams));

			recipe.Update(command.Name, command.Description, command.RecipeInfo, recipeIngredients);
			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}
