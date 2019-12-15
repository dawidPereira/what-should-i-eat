using System;

namespace Domain.RecipesDetails.Recipes.Entities
{
	[Flags]
	public enum MealType
	{
		None = 0,
		Breakfast = 1 << 1,
		Dinner = 1 << 2,
		Supper = 1 << 3,
		Snack = 1 << 4,
		Sweets = 1 << 5
	}
}