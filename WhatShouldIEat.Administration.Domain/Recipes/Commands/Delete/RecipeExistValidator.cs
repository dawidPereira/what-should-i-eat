using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete
{
	public class RecipeExistByIdValidator : ICommandValidator<DeleteRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public RecipeExistByIdValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(DeleteRecipeCommand command)
		{
			if(!_recipeRepository.ExistById(command.Id))
				Result.Fail(FailMessages.DoesNotExist(nameof(Recipe), 
					nameof(DeleteRecipeCommand.Id), command.Id.ToString()),404);
			
			return Result.Ok(200);
		}
	}
}