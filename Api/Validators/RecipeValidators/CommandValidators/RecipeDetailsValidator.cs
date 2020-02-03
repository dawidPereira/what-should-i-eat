using Domain.Recipes.Entities;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class RecipeDetailsValidator : AbstractValidator<RecipeInfo>
	{
		public RecipeDetailsValidator()
		{
			RuleFor(x => x.PreparationTime)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeInfo.PreparationTime), 0));
				
			RuleFor(x => x.ApproximateCost)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeInfo.PreparationTime), 0));
				
			RuleFor(x => x.DifficultyLevel)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThanOrEqualTo(nameof(RecipeInfo.PreparationTime), 0));
				
			RuleFor(x => x.DifficultyLevel)
				.LessThanOrEqualTo(5)
				.WithMessage(ValidationMessages.LowerThanOrEqualTo(nameof(RecipeInfo.PreparationTime), 5));
		}
	}
}