using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.QueryValidators
{
	public class GetIngredientQueryValidator : AbstractValidator<GetIngredientQuery>
	{
		public GetIngredientQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(GetIngredientQuery.Id)));
		}
	}
}