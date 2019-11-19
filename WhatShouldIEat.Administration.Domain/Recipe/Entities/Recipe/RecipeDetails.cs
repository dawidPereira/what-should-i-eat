using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class RecipeDetails
	{
		public RecipeDetails(int difficultyLevel,
			int preparationTime,
			decimal approximateCost,
			ICollection<MealType> mealTypes)
		{
			Id = new Id<RecipeDetails>(Guid.NewGuid());
			DifficultyLevel = difficultyLevel;
			PreparationTime = preparationTime;
			ApproximateCost = approximateCost;
			MealTypes = mealTypes;
		}
		
		public Id<RecipeDetails> Id { get; private set; }
		public int DifficultyLevel { get; private set; }
		public int PreparationTime { get; private set; }
		public decimal ApproximateCost { get; private set; }
		public ICollection<MealType> MealTypes { get; private set; }
	}
}