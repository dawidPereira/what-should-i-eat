using Domain.Ingredients.Entities.MacroNutrients;
using FluentValidation;

namespace Api.Validators.IngredientValidators.CommandValidators
{
	public class MacroNutrientsSharesValidator : AbstractValidator<MacroNutrientShare>
	{
		public MacroNutrientsSharesValidator() =>
			RuleFor(x => x.Share)
				.GreaterThan(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(MacroNutrientShare.Share), 0));
	}
}