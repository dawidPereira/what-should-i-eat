using Domain.Recipes.Queries.GetById;
using FluentValidation;

namespace Api.Validators.RecipeValidators.QueryValidators
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