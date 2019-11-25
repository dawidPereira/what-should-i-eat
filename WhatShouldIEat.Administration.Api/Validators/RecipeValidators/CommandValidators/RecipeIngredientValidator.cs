using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators.CommandValidators
{
	public class RecipeIngredientValidator : AbstractValidator<RecipeIngredient>
	{
		public RecipeIngredientValidator()
		{
			RuleFor(x => x.Grams)
				.GreaterThanOrEqualTo(1)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeIngredient.Grams), 0));

			RuleFor(x => x.IngredientId)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(RecipeIngredient.IngredientId)));

			RuleFor(x => x.RecipeId)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(RecipeIngredient.RecipeId)));
			
		}
	}
}