using System;
using System.Collections.Generic;
using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators
{
	public class MacroNutrientsParticipationValidator : AbstractValidator<IngredientMacroNutrient>
	{
		public MacroNutrientsParticipationValidator() =>
			RuleFor(x => x.ParticipationInIngredient)
				.GreaterThan(0)
				.WithMessage(ValidationMessages.GreaterThan(nameof(IngredientMacroNutrient.ParticipationInIngredient), 0));
	}
}