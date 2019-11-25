﻿using FluentValidation.Results;
using WhatShouldIEat.Administration.Api.Validators.RecipeValidators.CommandValidators;
using WhatShouldIEat.Administration.Api.Validators.RecipeValidators.QueryValidators;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Create;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Update;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipe;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators
{
	public class RecipeValidatorsFacade : IRecipeValidatorsFacade
	{
		private readonly CreateRecipeCommandValidator _createValidator;
		private readonly DeleteRecipeCommandValidator _deleteValidator;
		private readonly UpdateRecipeCommandValidator _updateValidator;
		private readonly GetRecipeQueryValidator _getValidator;

		public RecipeValidatorsFacade(CreateRecipeCommandValidator createValidator,
			DeleteRecipeCommandValidator deleteValidator,
			UpdateRecipeCommandValidator updateValidator,
			GetRecipeQueryValidator getValidator)
		{
			_createValidator = createValidator;
			_deleteValidator = deleteValidator;
			_updateValidator = updateValidator;
			_getValidator = getValidator;
		}

		public ValidationResult ValidateCreate(CreateRecipeCommand command) 
			=> _createValidator.Validate(command);
		
		public ValidationResult ValidateUpdate(UpdateRecipeCommand command) 
			=> _updateValidator.Validate(command);
		
		public ValidationResult ValidateDelete(DeleteRecipeCommand command) 
			=> _deleteValidator.Validate(command);
		
		public ValidationResult ValidateGet(GetRecipeQuery query) 
			=> _getValidator.Validate(query);
	}
}