using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Factory;
using WhatShouldIEat.Administration.Domain.Recipe.Mappers;
using WhatShouldIEat.Administration.Domain.Recipe.Repository;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command.Handlers
{
	public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IRecipeIngredientMapper _recipeIngredientMapper;
		private readonly IRecipeFactory _recipeFactory;

		public CreateRecipeCommandHandler(IIngredientRepository ingredientRepository,
			IRecipeRepository recipeRepository, 
			IRecipeIngredientMapper recipeIngredientMapper, IRecipeFactory recipeFactory)
		{
			_ingredientRepository = ingredientRepository;
			_recipeRepository = recipeRepository;
			_recipeIngredientMapper = recipeIngredientMapper;
			_recipeFactory = recipeFactory;
		}

		public Result Handle(CreateRecipeCommand command)
		{
			if (_recipeRepository.ExistByName(command.Name))
				return Result.Fail(FailMessages.AlreadyExist(nameof(Entities.Recipe.Recipe),
					nameof(CreateRecipeCommand.Name), command.Name));

			var recipe = _recipeFactory.Build(command);
			_recipeRepository.Add(recipe);
			return Result.Ok();
		}
		
	}
}