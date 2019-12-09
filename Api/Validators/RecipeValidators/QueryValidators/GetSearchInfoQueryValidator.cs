using Domain.Recipes.Queries.SearchInfoQueries.GetSearchInfo;
using FluentValidation;

namespace Api.Validators.RecipeValidators.QueryValidators
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