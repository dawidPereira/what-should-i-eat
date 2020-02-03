using Domain.Recipes.Entities;

namespace Infrastructure.Entities.Recipe
{
	public class RecipeInfo
	{
		private RecipeInfo() { }
		
		public RecipeInfo(int difficultyLevel, int preparationTime, decimal approximateCost, int servings, MealType mealTypes)
		{
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			Servings = servings;
			MealTypes = mealTypes;
		}
		public int DifficultyLevel { get; private set; }
		public int PreparationTime { get; private set; }
		public decimal ApproximateCost { get; private set; }
		public int Servings { get; private set; }
		public MealType MealTypes { get; private set; }

		public static RecipeInfo FromDomainRecipeInfo(Domain.Recipes.Entities.RecipeInfo recipeInfo) => 
			new RecipeInfo(recipeInfo.DifficultyLevel, recipeInfo.PreparationTime, recipeInfo.ApproximateCost, recipeInfo.Servings, recipeInfo.MealTypes);
	}
}