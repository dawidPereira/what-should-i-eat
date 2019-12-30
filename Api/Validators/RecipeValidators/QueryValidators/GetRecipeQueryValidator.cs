using Domain.Recipes.Queries.GetById;
using FluentValidation;

namespace Api.Validators.RecipeValidators.QueryValidators
{
	public class GetRecipeQueryValidator : AbstractValidator<GetByIdQuery>
	{
		public GetRecipeQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(GetByIdQuery.Id)));
		}
	}
}