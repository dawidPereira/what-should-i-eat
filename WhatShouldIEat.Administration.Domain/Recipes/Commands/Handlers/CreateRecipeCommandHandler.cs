using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Validators;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Handlers
{
	
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly CreateBaseRecipeCommandValidator _validator;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_validator = new CreateBaseRecipeCommandValidator(ingredientRepository, _recipeRepository);
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