using Domain.Recipes.Commands.Create;
using Domain.Recipes.Commands.Delete;
using Domain.Recipes.Commands.Update;
using Domain.Recipes.Queries.GetById;
using FluentValidation.Results;

namespace Api.Validators.RecipeValidators
{
	public interface IRecipeValidatorsFacade
	{
		ValidationResult ValidateCreate(CreateRecipeCommand command);
		ValidationResult ValidateUpdate(UpdateRecipeCommand command);
		ValidationResult ValidateDelete(DeleteRecipeCommand command);
		ValidationResult ValidateGet(GetRecipeQuery query);
	}
}