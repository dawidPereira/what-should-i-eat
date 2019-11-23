using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipes.Commands;

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