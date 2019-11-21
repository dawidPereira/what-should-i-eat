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
				.WithMessage(ErrorMessages.Required(nameof(UpdateIngredientCommand.Id)));
			
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(UpdateIngredientCommand.Name)));
			
			RuleFor(x => x.Allergens)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(UpdateIngredientCommand.Allergens)));
			
			RuleFor(x => x.Requirements)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(UpdateIngredientCommand.Requirements)));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required(nameof(UpdateIngredientCommand.MacroNutrients)));
			
			RuleForEach(x => x.MacroNutrients).
				SetValidator(new MacroNutrientTupleValidator());
		}
	}
}