﻿using FluentValidation;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;

namespace WhatShouldIEat.Administration.Api.Validators
{
	public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
	{
		public UpdateIngredientCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required("Id"));
			
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required("Name"));
			
			RuleFor(x => x.Allergens)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required("Allergens"));
			
			RuleFor(x => x.Requirements)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required("Requirements"));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ErrorMessages.Required("MacroNutrients"));
			
			RuleFor(x => x.MacroNutrients)
				.NotEmpty()
				.WithMessage(ErrorMessages.NotEmpty("MacroNutrients"));
			
			RuleForEach(x => x.MacroNutrients).
				SetValidator(new MacroNutrientTupleValidator());
		}
	}
}