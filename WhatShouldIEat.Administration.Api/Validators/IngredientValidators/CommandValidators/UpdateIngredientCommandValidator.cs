using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
	{
		public UpdateIngredientCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(UpdateIngredientCommand.Id)));
			
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(UpdateIngredientCommand.Name)));
			
			RuleFor(x => x.MacroNutrientsParticipation)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(UpdateIngredientCommand.MacroNutrientsParticipation)));
			
			RuleForEach(x => x.MacroNutrientsParticipation).
				SetValidator(new MacroNutrientsParticipationValidator());
		}
	}
}