using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Queries.GetById
{
	public class RecipeDto
	{
		public RecipeDto(Guid id, string name, string description, RecipeDetailsDto recipeDetails, ICollection<Tuple<Guid, double>> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeDetails = recipeDetails;
			RecipeIngredients = recipeIngredients;
		}
		
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public RecipeDetailsDto RecipeDetails { get; set; }
		public ICollection<Tuple<Guid, double>> RecipeIngredients { get; set; }

		public static RecipeDto FromRecipe(Recipe recipe)
		{
			var recipeDetailsDto = RecipeDetailsDto.FromRecipeDetails(recipe.RecipeInfo);
			var recipeIngredients = recipe.RecipeIngredients
				.Select(x => new Tuple<Guid, double>(x.IngredientId.Value, x.Grams))
				.ToList();
			return new RecipeDto(recipe.Id.Value, recipe.Name, recipe.Description, recipeDetailsDto, recipeIngredients);
		}

		public struct RecipeDetailsDto
		{
			private RecipeDetailsDto(int difficultyLevel, int preparationTime, decimal approximateCost, MealType mealTypes)
			{
				DifficultyLevel = difficultyLevel;
				PreparationTime = preparationTime;
				ApproximateCost = approximateCost;
				MealTypes = mealTypes;
			}
			public int DifficultyLevel { get; set; }
			public int PreparationTime { get; set; }
			public decimal ApproximateCost { get; set; }
			public MealType MealTypes { get; set; }
			
			public static RecipeDetailsDto FromRecipeDetails(RecipeInfo recipeInfo) =>
			new RecipeDetailsDto(recipeInfo.DifficultyLevel,
				recipeInfo.PreparationTime,
				recipeInfo.ApproximateCost,
				recipeInfo.MealTypes);
		}
	}
}