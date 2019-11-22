using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Command.Validators;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	using Recipe = Entities.Recipe.Recipe;
	
	public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly UpdateBaseRecipeCommandValidator _validator;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository,  IIngredientRepository ingredientRepository)
		{
			_recipeRepository = recipeRepository;
			_validator = new UpdateBaseRecipeCommandValidator(ingredientRepository, _recipeRepository);;
		}

		public Result Handle(UpdateRecipeCommand command)
		{
			var recipe = _recipeRepository.GetById(command.Id);
			var validationResult = _validator.Validate(recipe, command);
			if (validationResult.IsFailure)
				return validationResult;

			recipe.Update(command);
			_recipeRepository.Update(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
	}
}