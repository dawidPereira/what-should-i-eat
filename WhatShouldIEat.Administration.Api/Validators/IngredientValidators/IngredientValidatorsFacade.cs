using FluentValidation.Results;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.QueryValidators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators
{
	public class IngredientValidatorsFacade : IIngredientValidatorsFacade
	{
		private readonly CreateIngredientCommandValidator _createValidator;
		private readonly DeleteIngredientCommandValidator _deleteValidator;
		private readonly UpdateIngredientCommandValidator _updateValidator;
		private readonly GetIngredientQueryValidator _getValidator;

		public IngredientValidatorsFacade()
		{
			_createValidator = new CreateIngredientCommandValidator();
			_deleteValidator = new DeleteIngredientCommandValidator();
			_updateValidator = new UpdateIngredientCommandValidator();
			_getValidator = new GetIngredientQueryValidator();
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