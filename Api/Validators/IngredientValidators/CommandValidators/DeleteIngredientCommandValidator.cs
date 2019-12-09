using Domain.Ingredients.Commands.Delete;
using FluentValidation;

namespace Api.Validators.IngredientValidators.CommandValidators
{
	public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
	{
		public DeleteIngredientCommandValidator() =>
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithName(ValidationMessages.NotEmpty(nameof(DeleteIngredientCommand.Id)));
	}
}