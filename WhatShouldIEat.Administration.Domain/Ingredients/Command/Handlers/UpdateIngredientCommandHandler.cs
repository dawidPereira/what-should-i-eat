using System;
using System.Reflection.Metadata.Ecma335;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers
{
	public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository) => _ingredientRepository = ingredientRepository;

		public Result Handle(UpdateIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);

			if(ingredient == null)
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredient), 
					nameof(UpdateIngredientCommand.Id), command.Id.Value.ToString()));

			if (!command.Name.Equals(ingredient.Name))
				if (_ingredientRepository.ExistByName(command.Name))
					return Result.Fail(FailMessages.AlreadyExist(nameof(Ingredient), 
						nameof(UpdateIngredientCommand.Name), command.Name));
			
			ingredient.Update(command);
			_ingredientRepository.Update(ingredient);
			_ingredientRepository.Commit();
			
			return Result.Ok();
		}
	}
}