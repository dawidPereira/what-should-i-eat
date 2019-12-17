using Domain.Ingredients.Queries.Get;
using FluentValidation;

namespace Api.Validators.IngredientValidators.QueryValidators
{
	public class GetIngredientQueryValidator : AbstractValidator<GetIngredientQuery>
	{
		public GetIngredientQueryValidator()
		{
			RuleFor(x => x.IngredientId)
				.NotNull()
				.WithMessage(ValidationMessages.NotNull(nameof(GetIngredientQuery.IngredientId)));
		}
	}
}