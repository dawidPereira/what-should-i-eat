﻿using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Command.Validators;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	using Recipe = Entities.Recipe.Recipe;
	
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
			
			var recipe = new Recipe(command.Id, 
				command.Name, 
				command.Description, 
				command.RecipeIngredients, 
				command.RecipeDetails);
			
			_recipeRepository.Add(recipe);
			_recipeRepository.Commit();
			return Result.Ok();
		}
		
	}
}