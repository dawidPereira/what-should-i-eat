using Domain.Ingredients.Queries.GetIngredient;
using FluentValidation;

namespace Api.Validators.IngredientValidators.QueryValidators
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