namespace Domain.Recipes.Entities
{
	public class RecipeDetails
	{
		private RecipeDetails()
		{
		}
		
		public RecipeDetails(int difficultyLevel,
			int preparationTime,
			decimal approximateCost,
			MealType mealTypes)
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
	}
}