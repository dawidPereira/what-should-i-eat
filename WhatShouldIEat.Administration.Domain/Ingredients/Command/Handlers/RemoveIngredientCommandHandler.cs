using System.Reflection.Metadata.Ecma335;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers
{
	public class RemoveIngredientCommandHandler : ICommandHandler<RemoveIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public RemoveIngredientCommandHandler(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public Result Handle(RemoveIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);
			if(ingredient == null )
				return Result.Fail($"Ingredient with Id: {command.Id}, does not exist.");

			_ingredientRepository.Remove(ingredient);
			_ingredientRepository.Commit();
			return  Result.Ok();
		}
	}
}