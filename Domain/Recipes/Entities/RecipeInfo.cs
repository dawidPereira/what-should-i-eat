using Domain.Common.ValueObjects;

namespace Domain.Recipes.Entities
{
	//TODO: CreateNewOrUpdateExisting Validation
	public class RecipeInfo : IValueObject<RecipeInfo>
	{
		public RecipeInfo(int difficultyLevel,
			int preparationTime,
			decimal approximateCost,
			MealType mealTypes)
		{
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			MealTypes = mealTypes;
		}

		public RecipeInfo Update(int difficultyLevel, int preparationTime, decimal approximateCost, MealType mealTypes)
			=> new RecipeInfo(difficultyLevel, preparationTime, approximateCost, mealTypes);

		public int DifficultyLevel { get; }
		public int PreparationTime { get; }
		public decimal ApproximateCost { get; }
		public MealType MealTypes { get; }

		public bool Equals(RecipeInfo other)
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
			return obj.GetType() == GetType() && Equals((RecipeInfo) obj);
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