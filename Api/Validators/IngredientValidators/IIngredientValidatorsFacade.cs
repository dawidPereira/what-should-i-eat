using Domain.RecipesDetails.Ingredients.Commands.Create;
using Domain.RecipesDetails.Ingredients.Commands.Delete;
using Domain.RecipesDetails.Ingredients.Commands.Update;
using Domain.RecipesDetails.Ingredients.Queries.GetIngredient;
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