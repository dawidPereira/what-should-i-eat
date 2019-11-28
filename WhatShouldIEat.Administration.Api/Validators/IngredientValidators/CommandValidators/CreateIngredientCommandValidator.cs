using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
	{
		public CreateIngredientCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateIngredientCommand.Id)));
			
			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateIngredientCommand.Name)));
			
			RuleFor(x => x.MacroNutrientsParticipation)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(CreateIngredientCommand.MacroNutrientsParticipation)));

			RuleForEach(x => x.MacroNutrientsParticipation).
				SetValidator(new MacroNutrientsParticipationValidator());
		}
	}
}