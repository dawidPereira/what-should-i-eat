using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using WhatShouldIEat.Administration.Api.Validators;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Validators
{
	[TestFixture]
	internal class CreateIngredientCommandValidatorTests
	{
		private readonly CreateIngredientCommandValidator _systemUnderTest = new CreateIngredientCommandValidator();
		private CreateIngredientCommand _command;

		[SetUp]
		public void SetUp()
		{
			_command = CommandFactory.EmptyCreateIngredientCommand();
		}

		[Test]
		public void GivenCommandWithoutName_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.Name = null;
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ValidationMessages.NotNull("Name")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithoutMacroNutrients_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrientsParticipation = null;
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ValidationMessages.NotEmpty(nameof(CreateIngredientCommand.MacroNutrientsParticipation))))
				.Should().Be(1);
		}
		
		
		[Test]
		public void GivenCommandWithMacroNutrientsWithNegativeGrams_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrientsParticipation = new List<IngredientMacroNutrient>
			{
				new IngredientMacroNutrient(Guid.NewGuid(),  MacroNutrient.Carbohydrate,  -22)
			};
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(
					ValidationMessages.GreaterThan(nameof(IngredientMacroNutrient.ParticipationInIngredient), 0)))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithEmptyMacroNutrients_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrientsParticipation = new List<IngredientMacroNutrient>();
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ValidationMessages.NotEmpty(nameof(CreateIngredientCommand.MacroNutrientsParticipation))))
				.Should().Be(1);
		}
	}
}