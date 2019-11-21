using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
	{
		public CreateIngredientCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(ValidationMessages.Required(nameof(CreateIngredientCommand.Name)));
			
			RuleFor(x => x.Allergens)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(CreateIngredientCommand.Allergens)));
			
			RuleFor(x => x.Requirements)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(CreateIngredientCommand.Requirements)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(CreateIngredientCommand.MacroNutrients)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(CreateIngredientCommand.MacroNutrients)));
			
			RuleForEach(x => x.MacroNutrients).
				SetValidator(new MacroNutrientTupleValidator());
		}
	}
}