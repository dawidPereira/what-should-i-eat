using System;
using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Api.Validators
{
	public class MacroNutrientTupleValidator : AbstractValidator<Tuple<MacroNutrient, double>>
	{
		public MacroNutrientTupleValidator()
		{
			RuleFor(x => x.Item2).GreaterThanOrEqualTo(0);
		}
	}
}