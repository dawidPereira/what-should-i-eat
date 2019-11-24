using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Recipes.Commands;
using WhatShouldIEat.Administration.Domain.Recipes.Dtos;

namespace WhatShouldIEat.Administration.Domain.Recipes.Entities
{
	public class Recipe
	{
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
		public string Name { get;  private set; }
		public string Description { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }

		public static Recipe Create(CreateRecipeCommand command) => new Recipe(
				command.Id, 
				command.Name, 
				command.Description, 
				command.RecipeDetails,
				command.RecipeIngredients);

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