using FluentValidation.Results;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators
{
	public interface IIngredientValidatorsFacade
	{
		ValidationResult ValidateCreate(CreateIngredientCommand command);
		ValidationResult ValidateUpdate(UpdateIngredientCommand command);
		ValidationResult ValidateDelete(DeleteIngredientCommand command);
		ValidationResult ValidateGet(GetIngredientQuery query);
	}
}