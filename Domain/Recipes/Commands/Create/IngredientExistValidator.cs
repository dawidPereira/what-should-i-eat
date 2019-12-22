using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;

namespace Domain.Recipes.Commands.Create
{
	public class IngredientExistValidator : ICommandValidator<CreateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public IngredientExistValidator(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Validate(CreateRecipeCommand command)
		{
			foreach (var commandRecipeIngredient in command.RecipeIngredients)
			{
				var exist = _ingredientRepository.ExistById(commandRecipeIngredient.Ingredient.Id);
				if (!exist)
					Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient),
						nameof(CreateRecipeCommand.Id), command.Id.ToString()));
				//TODO: Fix bad Id
			}

			return Result.Ok();
		}
	}
}