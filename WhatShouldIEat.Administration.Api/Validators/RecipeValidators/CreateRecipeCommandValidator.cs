using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipes.Commands;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.CreateRecipeCommand;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators
{
	public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
	{
		public CreateRecipeCommandValidator()
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