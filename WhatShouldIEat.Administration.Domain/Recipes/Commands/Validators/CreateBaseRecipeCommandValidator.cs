using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators
{
	public class CreateBaseRecipeCommandValidator : BaseRecipeCommandValidator
	{
		public CreateBaseRecipeCommandValidator(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository) 
			: base(ingredientRepository, recipeRepository)
		{
		}
		public Result Validate(CreateRecipeCommand command) 
		{
			if (RecipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));
			
			ThrowExceptionIfAnyIngredientIdNotFound(command.RecipeIngredients.Select(x => x.IngredientId));
			
			return Result.Ok();
		}
	}
}