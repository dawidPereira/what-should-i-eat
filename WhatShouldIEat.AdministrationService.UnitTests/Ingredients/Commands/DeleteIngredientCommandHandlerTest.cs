using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecuoesBasisInfos;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;
using WhatShouldIEat.AdministrationService.Tests.Ingredients.Factories;

namespace WhatShouldIEat.AdministrationService.Tests.Ingredients.Commands
{
	[TestFixture]
	internal class DeleteIngredientCommandHandlerTest
	{
		private Mock<IIngredientRepository> _ingredientRepositoryMock;
		private Mock<IRecipeRepository> _recipeRepositoryMock;
		private IEnumerable<ICommandValidator<DeleteIngredientCommand>> _validators;
		private DeleteIngredientCommand _command;
		private DeleteIngredientCommandHandler _systemUnderTest;
		private Ingredient _ingredient;
		
		[SetUp]
		public void SetUp()
		{
			_ingredientRepositoryMock = new Mock<IIngredientRepository>();
			_recipeRepositoryMock = new Mock<IRecipeRepository>();
			_command = new DeleteIngredientCommand
			{
				Id = Guid.NewGuid()
			};
			var command = CommandFactory.CreateValidIngredientFactory("MyName");
			_ingredient = Ingredient.Create(
				command.Id, command.Name, command.Allergens, command.Requirements, command.MacroNutrientsParticipation);
			_validators = new List<ICommandValidator<DeleteIngredientCommand>>
			{
				new IngredientExistValidator(_ingredientRepositoryMock.Object),
				new NotUsedIngredientValidator(_recipeRepositoryMock.Object)
			};
			
			_systemUnderTest = new DeleteIngredientCommandHandler(_ingredientRepositoryMock.Object, _validators);
		}


		[Test]
		public void GivenIngredientId_WhenIngredientNotExist_ShouldReturnFailure()
		{
			var result  = _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
		}
		
		[Test]
		public void GivenIngredientId_WhenIngredientExist_ShouldReturnSuccess()
		{
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);

			var result  = _systemUnderTest.Handle(_command);
			result.IsSuccess.Should().BeTrue();
		}

		[Test]
		public void GivenIngredientId_WhenIngredientIsUsedInRecipe_ShouldReturnFailure()
		{
			var recipeBasicInfos = new List<RecipeBasicInfo>
			{
				new RecipeBasicInfo(Guid.NewGuid(),"ExistName")
			};
			
			_ingredientRepositoryMock.Setup(x => x.ExistById(It.IsAny<Guid>()))
				.Returns(true);
			_recipeRepositoryMock.Setup(x => x.GetRecipesBasicInfosByIngredientId(It.IsAny<Guid>()))
				.Returns(recipeBasicInfos);

			var result = _systemUnderTest.Handle(_command);
			result.IsFailure.Should().BeTrue();
			result.Message.Should()
				.Contain("Ingredient cannot be deleted. Ingredient is used in following recipes:");
		}
	}
}