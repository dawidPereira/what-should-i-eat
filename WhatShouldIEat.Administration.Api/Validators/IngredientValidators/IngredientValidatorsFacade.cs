using FluentValidation.Results;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.QueryValidators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators
{
	public class IngredientValidatorsFacade
	{
		private readonly CreateIngredientCommandValidator _createValidator;
		private readonly DeleteIngredientCommandValidator _deleteValidator;
		private readonly UpdateIngredientCommandValidator _updateValidator;
		private readonly GetIngredientQueryValidator _getValidator;

		public IngredientValidatorsFacade(CreateIngredientCommandValidator createValidator,
			DeleteIngredientCommandValidator deleteValidator,
			UpdateIngredientCommandValidator updateValidator,
			GetIngredientQueryValidator getValidator)
		{
			_createValidator = createValidator;
			_deleteValidator = deleteValidator;
			_updateValidator = updateValidator;
			_getValidator = getValidator;
		}
		
		public ValidationResult ValidateCreate(CreateIngredientCommand command) 
			=> _createValidator.Validate(command);
		
		public ValidationResult ValidateUpdate(UpdateIngredientCommand command) 
			=> _updateValidator.Validate(command);
		
		public ValidationResult ValidateDelete(DeleteIngredientCommand command) 
			=> _deleteValidator.Validate(command);
		
		public ValidationResult ValidateGet(GetIngredientQuery query) 
			=> _getValidator.Validate(query);
	}
}