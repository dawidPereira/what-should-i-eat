using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Entities
{
	public struct RecipeInfo : IValueObject<RecipeInfo>
	{
		public RecipeInfo(int difficultyLevel, int preparationTime, decimal approximateCost, int mealTypes)
		{
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			MealTypes = mealTypes;
		}
		
		public int DifficultyLevel { get; }
		public int PreparationTime { get; }
		public decimal ApproximateCost { get; }
		public int MealTypes { get; }

		public bool Equals(RecipeInfo other)
		{
			return DifficultyLevel == other.DifficultyLevel 
			       && PreparationTime == other.PreparationTime 
			       && ApproximateCost == other.ApproximateCost 
			       && MealTypes == other.MealTypes;
		}

		public override bool Equals(object obj)
		{
			return obj is RecipeInfo other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = DifficultyLevel;
				hashCode = (hashCode * 397) ^ PreparationTime;
				hashCode = (hashCode * 397) ^ ApproximateCost.GetHashCode();
				hashCode = (hashCode * 397) ^ MealTypes;
				return hashCode;
			}
		}
	}
}