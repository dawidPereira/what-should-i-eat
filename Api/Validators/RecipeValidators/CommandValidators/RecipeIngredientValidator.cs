﻿using Domain.Recipes.Dtos;
using Domain.Recipes.Entities;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class RecipeIngredientValidator : AbstractValidator<RecipeIngredientDto>
	{
		public RecipeIngredientValidator()
		{
			RuleFor(x => x.Grams)
				.GreaterThanOrEqualTo(1)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeIngredient.Grams), 0));

			RuleFor(x => x.IngredientId)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(RecipeIngredient.IngredientId)));
		}
	}
}