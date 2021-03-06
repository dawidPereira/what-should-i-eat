﻿using Domain.Recipes.Commands.Create;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
	{
		public CreateRecipeCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Id)));

			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Name)));

			RuleFor(x => x.Description)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Description)));

			RuleFor(x => x.RecipeInfo)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.RecipeInfo)));

			RuleFor(x => x.RecipeIngredients)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(CreateRecipeCommand.RecipeIngredients)));
			
			RuleFor(x => x.RecipeInfo)
				.SetValidator(new RecipeDetailsValidator());

			RuleForEach(x => x.RecipeIngredients)
				.SetValidator(new RecipeIngredientValidator());
		}
	}
}