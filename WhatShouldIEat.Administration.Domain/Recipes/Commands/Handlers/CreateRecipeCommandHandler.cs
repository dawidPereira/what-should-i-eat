using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Handlers
{
	
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IValidator<CreateRecipeCommand> _validator;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IValidator<CreateRecipeCommand> validator)
		{
			_recipeRepository = recipeRepository;
			_validator = validator;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			var validationResult = _validator.Validate(command);
			if (validationResult.IsFailure)
				return validationResult;

			var recipe = Recipe.Create(command);
			
			_recipeRepository.Add(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}