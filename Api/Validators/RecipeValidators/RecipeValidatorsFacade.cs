﻿using Api.Validators.RecipeValidators.CommandValidators;
using Api.Validators.RecipeValidators.QueryValidators;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Commands.Delete;
using Domain.Recipes.Commands.Update;
using Domain.Recipes.Queries.GetById;
using FluentValidation.Results;

namespace Api.Validators.RecipeValidators
{
	public class RecipeValidatorsFacade : IRecipeValidatorsFacade
	{
		private readonly CreateRecipeCommandValidator _createValidator;
		private readonly DeleteRecipeCommandValidator _deleteValidator;
		private readonly UpdateRecipeCommandValidator _updateValidator;
		private readonly GetRecipeQueryValidator _getValidator;

		public RecipeValidatorsFacade()
		{
			_createValidator = new CreateRecipeCommandValidator();
			_deleteValidator = new DeleteRecipeCommandValidator();
			_updateValidator = new UpdateRecipeCommandValidator();
			_getValidator = new GetRecipeQueryValidator();
		}

		public ValidationResult ValidateCreate(CreateRecipeCommand command) 
			=> _createValidator.Validate(command);
		
		public ValidationResult ValidateUpdate(UpdateRecipeCommand command) 
			=> _updateValidator.Validate(command);
		
		public ValidationResult ValidateDelete(DeleteRecipeCommand command) 
			=> _deleteValidator.Validate(command);
		
		public ValidationResult ValidateGet(GetByIdQuery query) 
			=> _getValidator.Validate(query);
	}
}