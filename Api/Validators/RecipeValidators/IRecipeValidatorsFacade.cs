using Domain.RecipesDetails.Recipes.Commands.Create;
using Domain.RecipesDetails.Recipes.Commands.Delete;
using Domain.RecipesDetails.Recipes.Commands.Update;
using Domain.RecipesDetails.Recipes.Queries.GetById;
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