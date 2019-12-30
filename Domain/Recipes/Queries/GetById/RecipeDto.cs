using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Queries.GetById
{
	public struct RecipeDto
	{
		public RecipeDto(Guid id, string name, string description, RecipeDetailsDto recipeInfo, IDictionary<Guid, double> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		
		public Guid Id { get; }
		public string Name { get; }
		public string Description { get; }
		public RecipeDetailsDto RecipeInfo { get; }
		public IDictionary<Guid, double> RecipeIngredients { get; }

		public static RecipeDto FromRecipe(Recipe recipe)
		{
			var recipeDetailsDto = RecipeDetailsDto.FromRecipeDetails(recipe.RecipeInfo);
			var recipeIngredients = recipe.RecipeIngredients
				.ToDictionary(x => x.IngredientId.Value, x => x.Grams);
			return new RecipeDto(recipe.Id.Value, recipe.Name, recipe.Description, recipeDetailsDto, recipeIngredients);
		}

		public struct RecipeDetailsDto
		{
			private RecipeDetailsDto(int difficultyLevel, int preparationTime, decimal approximateCost, int mealTypes)
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
			
			public static RecipeDetailsDto FromRecipeDetails(RecipeInfo recipeInfo) =>
			new RecipeDetailsDto(recipeInfo.DifficultyLevel,
				recipeInfo.PreparationTime,
				recipeInfo.ApproximateCost,
				(int)recipeInfo.MealTypes);
		}
	}
}