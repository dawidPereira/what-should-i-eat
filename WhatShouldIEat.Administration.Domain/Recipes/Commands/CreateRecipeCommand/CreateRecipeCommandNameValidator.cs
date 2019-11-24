using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.CreateRecipeCommand
{
	public class CreateRecipeCommandNameValidator : ICommandValidator<CreateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IRecipeRepository _recipeRepository;

		public CreateRecipeCommandNameValidator(IIngredientRepository ingredientRepository,
			IRecipeRepository recipeRepository)
		{
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
		}

		public Result Validate(CreateRecipeCommand command)
		{
			if (_recipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name), 400);
			
			return Result.Ok(200);
		}
	}
}

