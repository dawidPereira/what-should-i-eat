using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Mediator;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Events.Updated;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Update
{
	public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand>
	{
		private readonly IMediator _mediator;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IEnumerable<ICommandValidator<UpdateRecipeCommand>> _validators;

		public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, 
			IEnumerable<ICommandValidator<UpdateRecipeCommand>> validators, 
			IMediator mediator)
		{
			_recipeRepository = recipeRepository;
			_validators = validators;
			_mediator = mediator;
		}

		public Result Handle(UpdateRecipeCommand command)
		{
			foreach (var validator in _validators)
			{
				var validationResult = validator.Validate(command);
				if (validationResult.IsFailure)
					return validationResult;
			}
			
			var recipe = _recipeRepository.GetById(command.Id);
			
			recipe.Update(command);
			_recipeRepository.Commit();
			_mediator.Publish(new RecipeUpdatedEvent(recipe.CalculateSearchInfo()));
			return Result.Ok();
		}
	}
}