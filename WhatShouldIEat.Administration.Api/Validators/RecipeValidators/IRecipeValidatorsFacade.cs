using FluentValidation.Results;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Create;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Update;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipe;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators
{
	public interface IRecipeValidatorsFacade
	{
		ValidationResult ValidateCreate(CreateRecipeCommand command);
		ValidationResult ValidateUpdate(UpdateRecipeCommand command);
		ValidationResult ValidateDelete(DeleteRecipeCommand command);
		ValidationResult ValidateGet(GetRecipeQuery query);
	}
}