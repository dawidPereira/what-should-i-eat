using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

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
				return Result.Fail(FailMessages.DoesNotExist(nameof(Ingredients), 
					nameof(RemoveIngredientCommand.Id), command.Id.ToString()));

			_ingredientRepository.Remove(ingredient);
			_ingredientRepository.Commit();
			return  Result.Ok();
		}
	}
}