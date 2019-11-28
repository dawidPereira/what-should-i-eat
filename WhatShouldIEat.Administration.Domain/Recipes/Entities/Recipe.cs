using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Update;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipe;

namespace WhatShouldIEat.Administration.Domain.Recipes.Entities
{
	public class Recipe
	{
		private Recipe()
		{
		}

		private Recipe(Guid id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			ICollection<RecipeIngredient> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeDetails = recipeDetails;
			RecipeIngredients = recipeIngredients;
		}

		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Recipe Create(
			Guid id,
			string name,
			string description,
			RecipeDetails recipeDetails,
			ICollection<RecipeIngredient> recipeIngredients) =>
			new Recipe(id, name, description, recipeDetails, recipeIngredients);

		public void Update(UpdateRecipeCommand command)
		{
			Id = command.Id;
			Name = command.Name;
			Description = command.Description;
			RecipeDetails = command.RecipeDetails;
			RecipeIngredients = command.RecipeIngredients;
		}

		public RecipeDto ToDto() => new RecipeDto
		{
			Id = Id,
			Name = Name,
			Description = Description,
			RecipeDetails = RecipeDetails,
			RecipeIngredients = RecipeIngredients
		};

		public double CalculateCalories() =>
			RecipeIngredients.Sum(x => x.Ingredient.CalculateCalories(x.Grams));
	}
}