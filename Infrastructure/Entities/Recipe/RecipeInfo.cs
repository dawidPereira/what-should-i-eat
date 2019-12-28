using Domain.Recipes.Entities;

namespace Infrastructure.Entities.Recipe
{
	public class RecipeInfo
	{
		public RecipeInfo(int difficultyLevel, int preparationTime, decimal approximateCost, MealType mealTypes)
		{
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			MealTypes = mealTypes;
		}
		public int DifficultyLevel { get; private set; }
		public int PreparationTime { get; private set; }
		public decimal ApproximateCost { get; private set; }
		public MealType MealTypes { get; private set; }

		public static RecipeInfo FromDomainRecipeInfo(Domain.Recipes.Entities.RecipeInfo recipeInfo) => 
			new RecipeInfo(recipeInfo.DifficultyLevel, recipeInfo.PreparationTime, recipeInfo.ApproximateCost, recipeInfo.MealTypes);
	}
}