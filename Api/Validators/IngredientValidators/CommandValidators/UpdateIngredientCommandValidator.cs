using Domain.Ingredients.Commands.Update;
using FluentValidation;

namespace Api.Validators.IngredientValidators.CommandValidators
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
			
			RuleFor(x => x.Shares)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(UpdateIngredientCommand.Shares)));
			
			RuleForEach(x => x.Shares).
				SetValidator(new MacroNutrientsSharesValidator());
		}
	}
}