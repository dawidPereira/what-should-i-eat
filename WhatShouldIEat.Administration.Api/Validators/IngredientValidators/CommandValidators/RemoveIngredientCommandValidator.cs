using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class RemoveIngredientCommandValidator : AbstractValidator<RemoveIngredientCommand>
	{
		public RemoveIngredientCommandValidator() =>
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithName(ValidationMessages.Required(nameof(RemoveIngredientCommand.Id)));
	}
}