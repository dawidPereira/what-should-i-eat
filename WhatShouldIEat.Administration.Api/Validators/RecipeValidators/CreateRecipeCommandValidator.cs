using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipe.Command;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators
{
	public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
	{
		public CreateRecipeCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(ValidationMessages.Required(nameof(CreateRecipeCommand.Name)));

			RuleFor(x => x.Description)
				.NotNull()
				.WithMessage(ValidationMessages.Required(nameof(CreateRecipeCommand.Description)));

			RuleFor(x => x.RecipeIngredients)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(CreateRecipeCommand.RecipeIngredients)));
			
			RuleForEach(x => x.RecipeIngredients)
				.ChildRules(x => x.RuleFor( y => y.Item1)
					.NotNull()
					.WithMessage(ValidationMessages.Required(nameof(Ingredient.Id))));

			RuleForEach(x => x.RecipeIngredients)
				.ChildRules(x => x.RuleFor(y => y.Item2))
				.NotNull()
				.WithMessage(ValidationMessages.Required(nameof(RecipeIngredient.Grams)));
			
			RuleFor(x => x.ApproximateCost)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(RecipeDetails.ApproximateCost), 0));
			
			RuleFor(x => x.DifficultyLevel)
				.GreaterThan(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(RecipeDetails.DifficultyLevel), 0))
				.LessThanOrEqualTo(5)
				.WithMessage(ValidationMessages.LowerThan(nameof(RecipeDetails.DifficultyLevel),5));

			RuleFor(x => x.PreparationTime)
				.GreaterThan(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(RecipeDetails.PreparationTime), 0));

			RuleFor(x => x.MealTypes)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(RecipeDetails.MealTypes)));
		}
	}
}