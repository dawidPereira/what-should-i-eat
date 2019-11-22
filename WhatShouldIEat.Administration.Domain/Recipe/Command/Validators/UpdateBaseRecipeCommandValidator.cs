using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Validators
{
	using Recipe = Entities.Recipe.Recipe;
	
	public class UpdateBaseRecipeCommandValidator : BaseRecipeCommandValidator
	{
		public UpdateBaseRecipeCommandValidator(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository) : 
			base(ingredientRepository, recipeRepository)
		{
		}

		public Result Validate(Recipe recipe, UpdateRecipeCommand command)
		{
			if (recipe == null)
				return Result.Fail(FailMessages.DoesNotExist(nameof(Recipe),
					nameof(UpdateRecipeCommand.Id), command.Id.ToString()));

			if (recipe.Name != command.Name && RecipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));
			
			ThrowExceptionIfAnyIngredientIdNotFound(command.RecipeIngredients.Select(x => x.IngredientId));
			
			return Result.Ok();
		}
	}
}