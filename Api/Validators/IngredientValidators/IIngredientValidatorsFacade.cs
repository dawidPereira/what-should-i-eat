using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Commands.Delete;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Queries.Get;
using FluentValidation.Results;

namespace Api.Validators.IngredientValidators
{
	public interface IIngredientValidatorsFacade
	{
		ValidationResult ValidateCreate(CreateIngredientCommand command);
		ValidationResult ValidateUpdate(UpdateIngredientCommand command);
		ValidationResult ValidateDelete(DeleteIngredientCommand command);
		ValidationResult ValidateGet(GetIngredientQuery query);
	}
}