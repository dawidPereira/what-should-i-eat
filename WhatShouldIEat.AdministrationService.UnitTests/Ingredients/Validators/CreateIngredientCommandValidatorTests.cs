using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using WhatShouldIEat.Administration.Api.Validators;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators.CommandValidators;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
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
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.Required("Name")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithoutAllergens_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.Allergens = null;
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.Required("Allergens")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithoutMacroNutrients_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrients = null;
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.Required("MacroNutrients")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithoutRequirements_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrients = null;
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.Required("Requirements")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithMacroNutrientsWithNegativeGrams_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>
			{
				new Tuple<MacroNutrient, double>(MacroNutrient.Carbohydrate, -22)
			};
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.GreaterThanZero("MacroNutrients.Grams")))
				.Should().Be(1);
		}
		
		[Test]
		public void GivenCommandWithEmptyMacroNutrients_WhenRequired_ShouldBeNotValidWithProperErrorMessage()
		{
			_command.MacroNutrients = new HashSet<Tuple<MacroNutrient, double>>();
			var result = _systemUnderTest.Validate(_command);
			result.IsValid.Should().BeFalse();
			result.Errors.Count(x => x.ErrorMessage.Equals(ErrorMessages.NotEmpty("MacroNutrients")))
				.Should().Be(1);
		}
	}
}