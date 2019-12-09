using System.Text;
using Domain.Common.Extensions;
using Domain.Common.Messages;
using Domain.Common.Validators;
using Domain.Common.ValueObjects;
using Domain.Recipes.Repositories;

namespace Domain.Ingredients.Commands.Delete
{
	public class NotUsedIngredientValidator : ICommandValidator<DeleteIngredientCommand>
	{
		private readonly IRecipeRepository _recipeRepository;

		public NotUsedIngredientValidator(IRecipeRepository recipeRepository) => 
			_recipeRepository = recipeRepository;

		public Result Validate(DeleteIngredientCommand command)
		{
			var recipesWithIngredient = _recipeRepository.GetRecipesBasicInfosByIngredientId(command.Id);
			if (recipesWithIngredient == null) return Result.Ok();
			
			var message = new StringBuilder();
			message.AppendLine("Ingredient cannot be deleted. Ingredient is used in following recipes:");
			recipesWithIngredient.ForEach(x => message.AppendLine($"RecipeName: {x.Name} | RecipeId: {x.Id}."));
			return Result.Fail(ResultCode.BadRequest, message.ToString());
		}
	}
}