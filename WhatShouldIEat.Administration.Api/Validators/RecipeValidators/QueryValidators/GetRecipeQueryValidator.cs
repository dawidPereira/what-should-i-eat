using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipes.Queries;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators.QueryValidators
{
	public class GetRecipeQueryValidator : AbstractValidator<GetRecipeQuery>
	{
		public GetRecipeQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(GetRecipeQuery.Id)));
		}
	}
}