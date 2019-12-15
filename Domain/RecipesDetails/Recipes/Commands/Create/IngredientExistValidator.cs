using Domain.Common.Mediators.Validators;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.RecipesDetails.Ingredients.Commands.Update;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Repositories;

namespace Domain.RecipesDetails.Recipes.Commands.Create
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
				var exist = _ingredientRepository.ExistById(commandRecipeIngredient.IngredientId);
				if (!exist)
					Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Ingredient),
						nameof(UpdateIngredientCommand.Id), command.Id.ToString()));
			}

			return Result.Ok();
		}
	}
}