using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Validators
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