﻿using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public Result Handle(CreateIngredientCommand command)
		{
			if(_ingredientRepository.ExistByName(command.Name))
				return Result.Fail($"Ingredient {command.Name}, already exist.");
			
			var ingredient = new Ingredient(command.Name, command.Allergens, command.Requirements, command.MacroNutrients);

			_ingredientRepository.Add(ingredient);
			_ingredientRepository.Commit();
			
			return Result.Ok();
		}
	}
}