using Domain.Recipes.Commands.Delete;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
	{
		public DeleteRecipeCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(DeleteRecipeCommand.Id)));
		}
	}
}