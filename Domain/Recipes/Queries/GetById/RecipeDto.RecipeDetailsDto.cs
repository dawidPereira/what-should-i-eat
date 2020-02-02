using Domain.Recipes.Entities;

namespace Domain.Recipes.Queries.GetById
{
	public partial struct RecipeDto
	{
		public struct RecipeDetailsDto
		{
			private RecipeDetailsDto(int difficultyLevel, int preparationTime, decimal approximateCost, string mealTypes)
			{
				DifficultyLevel = difficultyLevel;
				PreparationTime = preparationTime;
				ApproximateCost = approximateCost;
				MealTypes = mealTypes;
			}
			public int DifficultyLevel { get; }
			public int PreparationTime { get; }
			public decimal ApproximateCost { get; }
			public string MealTypes { get; }
			
			public static RecipeDetailsDto FromRecipeDetails(RecipeInfo recipeInfo) =>
				new RecipeDetailsDto(recipeInfo.DifficultyLevel,
					recipeInfo.PreparationTime,
					recipeInfo.ApproximateCost,
					recipeInfo.MealTypes.ToString());
		}
	}
}