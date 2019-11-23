using System.Collections.Generic;

namespace WhatShouldIEat.Administration.Domain.Recipes.Entities
{
	public class RecipeDetails
	{
		public RecipeDetails(int difficultyLevel,
			int preparationTime,
			decimal approximateCost,
			ICollection<MealType> mealTypes)
		{
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			MealTypes = mealTypes;
		}
		
		public int DifficultyLevel { get; private set; }
		public int PreparationTime { get; private set; }
		public decimal ApproximateCost { get; private set; }
		public ICollection<MealType> MealTypes { get; private set; }
	}
}