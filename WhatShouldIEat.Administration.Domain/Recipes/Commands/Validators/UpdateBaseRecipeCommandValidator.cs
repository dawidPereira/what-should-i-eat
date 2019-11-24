using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators
{
	public class UpdateBaseRecipeCommandValidator : IValidator<UpdateRecipeCommand, Recipe>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IIngredientRepository _ingredientRepository;

		public UpdateBaseRecipeCommandValidator(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
		{
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
		}

		public Result Validate(UpdateRecipeCommand command, Recipe recipe)
		{
			if (recipe == null)
				return Result.Fail(FailMessages.DoesNotExist(nameof(Recipe),
					nameof(UpdateRecipeCommand.Id), command.Id.ToString()));

			if (recipe.Name != command.Name && _recipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));
			
			foreach (var commandRecipeIngredient in command.RecipeIngredients)
			{
				var exist = _ingredientRepository.ExistById(commandRecipeIngredient.IngredientId);
				if(!exist) Exceptions<Ingredient>.ThrowNotFoundException(nameof(Ingredient), 
					commandRecipeIngredient.IngredientId.ToString());
			}
			
			return Result.Ok();
		}
	}
}