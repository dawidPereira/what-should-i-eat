using System.Text;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete
{
	public class NotUsedIngredientValidator : ICommandValidator<DeleteIngredientCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public NotUsedIngredientValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(DeleteIngredientCommand command)
		{
			var recipesWithIngredient = _recipeRepository.GetRecipesBasicInfosByIngredientId(command.Id);
			if (recipesWithIngredient == null) return Result.Ok(200);
			
			var message = new StringBuilder();
			message.AppendLine("Ingredient cannot be deleted. Ingredient is used in following recipes:");
			recipesWithIngredient.ForEach(x => message.AppendLine($"RecipeName: {x.Name} | RecipeId: {x.Id}."));
			return Result.Fail(message.ToString(), 400);
		}
	}
}