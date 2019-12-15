﻿using Domain.RecipesDetails.Recipes.Entities;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class RecipeDetailsValidator : AbstractValidator<RecipeDetails>
	{
		public RecipeDetailsValidator()
		{
			RuleFor(x => x.PreparationTime)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeDetails.PreparationTime), 0));
				
			RuleFor(x => x.ApproximateCost)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeDetails.PreparationTime), 0));
				
			RuleFor(x => x.DifficultyLevel)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeDetails.PreparationTime), 0));
				
			RuleFor(x => x.DifficultyLevel)
				.LessThanOrEqualTo(5)
				.WithMessage(ValidationMessages.LowerThanOrEqualTo(nameof(RecipeDetails.PreparationTime), 5));
				
			RuleFor(x => x.MealTypes)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(RecipeDetails.MealTypes)));
		}
	}
}