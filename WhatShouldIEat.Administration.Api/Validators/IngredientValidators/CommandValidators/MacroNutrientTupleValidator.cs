using System;
using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class MacroNutrientTupleValidator : AbstractValidator<Tuple<MacroNutrient, double>>
	{
		public MacroNutrientTupleValidator() =>
			RuleFor(x => x.Item2)
				.GreaterThanOrEqualTo(0)
				.WithMessage(ValidationMessages.GreaterThan("Grams", 0));
	}
}