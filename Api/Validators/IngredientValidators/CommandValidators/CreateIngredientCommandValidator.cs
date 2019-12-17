using Domain.Ingredients.Commands.Create;
using FluentValidation;

namespace Api.Validators.IngredientValidators.CommandValidators
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
			
			RuleFor(x => x.Shares)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(CreateIngredientCommand.Shares)));

			RuleForEach(x => x.Shares)
				.SetValidator(new MacroNutrientsSharesValidator());
		}
	}
}