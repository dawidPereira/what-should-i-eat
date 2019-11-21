using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	using Recipe = Recipe.Entities.Recipe.Recipe;
	
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IRecipeRepository _recipeRepository;

		public CreateRecipeCommandHandler(IIngredientRepository ingredientRepository, IRecipeRepository recipeRepository)
		{
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			if(_recipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Recipe), 
					nameof(CreateRecipeCommand.Name), command.Name));
			
			var recipeDetails = new RecipeDetails(command.DifficultyLevel, 
				command.PreparationTime,
				command.ApproximateCost, 
				command.MealTypes);
			
			//var recipe = new Recipe(command.Name, command.Description,)
			return Result.Ok();
		}

//		private ICollection<Tuple<Id<Ingredient>, double>> CreateIngredientsHashSet(CreateRecipeCommand command)
//		{
//			
//		}
	}
	

	public interface IRecipeRepository
	{
		void Add(Ingredient ingredient);
		void Commit();
		bool ExistByName(string name);
		bool ExistById(string id);
		
	}
}