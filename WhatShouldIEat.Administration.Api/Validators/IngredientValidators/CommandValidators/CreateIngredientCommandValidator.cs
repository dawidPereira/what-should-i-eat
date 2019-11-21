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
				.WithMessage(ErrorMessages.Required(nameof(CreateIngredientCommand.Name)));
			
			RuleFor(x => x.Allergens)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(CreateIngredientCommand.Allergens)));
			
			RuleFor(x => x.Requirements)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(CreateIngredientCommand.Requirements)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(CreateIngredientCommand.MacroNutrients)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ErrorMessages.NotEmpty(nameof(CreateIngredientCommand.MacroNutrients)));
			
			RuleForEach(x => x.MacroNutrients).
				SetValidator(new MacroNutrientTupleValidator());
		}
	}
}