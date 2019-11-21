using WhatShouldIEat.Administration.Domain.Recipe.Command;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;
using WhatShouldIEat.Administration.Domain.Recipe.Mappers;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Factory
{
	using Recipe = Recipe.Recipe;

	public class RecipeFactory : IRecipeFactory
	{
		private readonly IRecipeIngredientMapper _recipeIngredientMapper;

		public RecipeFactory(IRecipeIngredientMapper recipeIngredientMapper)
		{
			_recipeIngredientMapper = recipeIngredientMapper;
		}

		public Recipe Build(CreateRecipeCommand command)
		{
			var recipeIngredients = _recipeIngredientMapper
				.MapToListOfRecipeIngredients(command.RecipeIngredients, command.Id);
			var mealTypes = _recipeIngredientMapper.MapToMealTypes(command.MealTypes);
			var recipeDetails = new RecipeDetails(command.DifficultyLevel,
				command.PreparationTime,
				command.ApproximateCost,
				mealTypes);

			return new Recipe(command.Name, command.Description, recipeIngredients, recipeDetails);
		}
	}
}