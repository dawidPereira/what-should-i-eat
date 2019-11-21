using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
	{
		public UpdateIngredientCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(UpdateIngredientCommand.Id)));
			
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(UpdateIngredientCommand.Name)));
			
			RuleFor(x => x.Allergens)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(UpdateIngredientCommand.Allergens)));
			
			RuleFor(x => x.Requirements)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(UpdateIngredientCommand.Requirements)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ValidationMessages.Required(nameof(UpdateIngredientCommand.MacroNutrients)));
			
			RuleForEach(x => x.MacroNutrients).
				SetValidator(new MacroNutrientTupleValidator());
		}
	}
}