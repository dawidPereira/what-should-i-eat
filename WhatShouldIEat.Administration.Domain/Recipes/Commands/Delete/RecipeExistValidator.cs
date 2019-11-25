using WhatShouldIEat.Administration.Domain.Common.Messages;
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
				Result.Fail(ResultCode.NotFound, FailMessages.DoesNotExist(nameof(Recipe), 
					nameof(DeleteRecipeCommand.Id), command.Id.ToString()));
			
			return Result.Ok();
		}
	}
}