using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Recipes.Entities
{
	//TODO: Add Validation
	public class RecipeDetails : IValueObject<RecipeDetails>
	{
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

		public RecipeDetails Update(int difficultyLevel, int preparationTime, decimal approximateCost, MealType mealTypes)
			=> new RecipeDetails(difficultyLevel, preparationTime, approximateCost, mealTypes);

		public int DifficultyLevel { get; }
		public int PreparationTime { get; }
		public decimal ApproximateCost { get; }
		public MealType MealTypes { get; }

		public bool Equals(RecipeDetails other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return DifficultyLevel == other.DifficultyLevel
			       && PreparationTime == other.PreparationTime
			       && ApproximateCost == other.ApproximateCost
			       && MealTypes == other.MealTypes;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RecipeDetails) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = DifficultyLevel;
				hashCode = (hashCode * 397) ^ PreparationTime;
				hashCode = (hashCode * 397) ^ ApproximateCost.GetHashCode();
				hashCode = (hashCode * 397) ^ (int) MealTypes;
				return hashCode;
			}
		}
	}
}