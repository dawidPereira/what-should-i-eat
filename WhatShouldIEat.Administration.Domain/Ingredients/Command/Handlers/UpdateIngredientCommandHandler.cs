using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command.Handlers
{
	public class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}

		public Result Handle(UpdateIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);
			
			if(ingredient == null)
				return Result.Fail($"Ingredient with Id: {command.Id.Value}, does not exist.");

			if (!command.Name.Equals(ingredient.Name))
				if (_ingredientRepository.ExistByName(command.Name))
					return Result.Fail($"Ingredient {command.Name}, already exist.");
			
			ingredient.Update(command);
			_ingredientRepository.Update(ingredient);
			_ingredientRepository.Commit();
			
			return Result.Ok();
		}
	}
}