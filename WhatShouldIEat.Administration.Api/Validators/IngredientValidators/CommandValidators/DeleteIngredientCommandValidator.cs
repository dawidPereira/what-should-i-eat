using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
	{
		public DeleteIngredientCommandValidator() =>
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithName(ValidationMessages.NotEmpty(nameof(DeleteIngredientCommand.Id)));
	}
}