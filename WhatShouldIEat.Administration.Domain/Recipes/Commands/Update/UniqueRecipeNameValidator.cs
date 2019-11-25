using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Create;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Update
{
	public class UniqueRecipeNameValidator : ICommandValidator<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public UniqueRecipeNameValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(UpdateRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			if (recipe.Name != command.Name && _recipeRepository.ExistByName(command.Name))
				return Result.Fail(ResultCode.BadRequest, FailMessages.AlreadyExist(nameof(Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));
			
			return Result.Ok();
		}
	}
}