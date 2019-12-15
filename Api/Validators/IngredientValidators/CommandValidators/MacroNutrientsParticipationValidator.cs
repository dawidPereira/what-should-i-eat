using Domain.RecipesDetails.Ingredients.Entities;
using FluentValidation;

namespace Api.Validators.IngredientValidators.CommandValidators
{
	public class MacroNutrientsParticipationValidator : AbstractValidator<IngredientMacroNutrient>
	{
		public MacroNutrientsParticipationValidator() =>
			RuleFor(x => x.ParticipationInIngredient)
				.GreaterThan(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(IngredientMacroNutrient.ParticipationInIngredient), 0));
	}
}