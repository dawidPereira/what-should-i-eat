using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;

namespace WhatShouldIEat.Administration.Api.Validators
{
	public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
	{
		public CreateIngredientCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").When(x => x.Allergens != null);
			RuleFor(x => x.Allergens).NotEmpty();
			RuleFor(x => x.Requirements).NotEmpty();
			RuleFor(x => x.MacroNutrients).NotEmpty();
			RuleForEach(x => x.MacroNutrients).SetValidator(new MacroNutrientTupleValidator());
		}
	}
}