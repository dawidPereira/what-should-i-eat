using Domain.Recipes.Commands.Create;
using Domain.Recipes.Commands.Update;
using FluentValidation;

namespace Api.Validators.RecipeValidators.CommandValidators
{
	public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
	{
		public UpdateRecipeCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Id)));

			RuleFor(x => x.Name)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Name)));

			RuleFor(x => x.Description)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.Description)));

			RuleFor(x => x.RecipeDetails)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(CreateRecipeCommand.RecipeDetails)));

			RuleFor(x => x.RecipeIngredients)
				.NotEmpty()
				.WithMessage(ValidationMessages.NotEmpty(nameof(CreateRecipeCommand.RecipeIngredients)));
			
			RuleFor(x => x.RecipeDetails)
				.SetValidator(new RecipeDetailsValidator());

			RuleForEach(x => x.RecipeIngredients)
				.SetValidator(new RecipeIngredientValidator());
		}
	}
}