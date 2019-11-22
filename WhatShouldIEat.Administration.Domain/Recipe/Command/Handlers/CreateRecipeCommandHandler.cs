using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipe.Mappers;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	using Recipe = Entities.Recipe.Recipe;
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeIngredientValidator _recipeIngredientValidator;

		public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, 
			IRecipeIngredientValidator recipeIngredientValidator)
		{
			_recipeRepository = recipeRepository;
			_recipeIngredientValidator = recipeIngredientValidator;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			if (_recipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Entities.Recipe.Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));
			
			_recipeIngredientValidator.ThrowExceptionIfAnyIngredientIdNotFound(
				command.RecipeIngredients.Select(x => x.IngredientId));
			
			var recipe = new Recipe(command.Id, 
				command.Name, 
				command.Description, 
				command.RecipeIngredients, 
				command.RecipeDetails);
			
			_recipeRepository.Add(recipe);
			return Result.Ok();
		}
		
	}
}