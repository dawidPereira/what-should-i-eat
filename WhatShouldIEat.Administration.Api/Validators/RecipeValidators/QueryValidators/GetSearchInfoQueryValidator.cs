using FluentValidation;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo;

namespace WhatShouldIEat.Administration.Api.Validators.RecipeValidators.QueryValidators
{
	public class GetSearchInfoQueryValidator : AbstractValidator<GetSearchInfoQuery>
	{
		public GetSearchInfoQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(GetSearchInfoQuery.Id)));
		}
	}
}