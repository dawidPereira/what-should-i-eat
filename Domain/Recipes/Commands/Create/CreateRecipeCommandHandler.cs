using System.Collections.Generic;
using System.Linq;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Validators;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Recipes.Factories;
using Domain.Recipes.Services;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IImageUploader _imageUploader;
		private readonly IRecipeFactory _recipeFactory;
		private readonly IRecipeIngredientFactory _recipeIngredientFactory;
		private readonly IEnumerable<ICommandValidator<CreateRecipeCommand>> _validators;

		public CreateRecipeCommandHandler(
			IEnumerable<ICommandValidator<CreateRecipeCommand>> validators,
			IEventPublisher eventPublisher, 
			IRecipeFactory recipeFactory, 
			IRecipeIngredientFactory recipeIngredientFactory, 
			IImageUploader imageUploader)
		{
			_validators = validators;
			_eventPublisher = eventPublisher;
			_recipeFactory = recipeFactory;
			_recipeIngredientFactory = recipeIngredientFactory;
			_imageUploader = imageUploader;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}

			var imageUrl = _imageUploader.Upload(command.Image, command.Id.ToString(), command.Name);
			
			var recipeIngredients = command.RecipeIngredients.Select(x =>
				_recipeIngredientFactory.Create(x.IngredientId, x.Grams));

			_recipeFactory.Create(command.Id,
				command.Name,
				command.Description,
				imageUrl,
				command.RecipeInfo,
				recipeIngredients);


			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}