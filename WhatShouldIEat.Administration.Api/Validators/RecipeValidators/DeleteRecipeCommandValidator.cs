using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipe.Command;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators
{
	public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
	{
		public DeleteRecipeCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(DeleteRecipeCommand.Id)));
		}
	}
}