using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe
{
	public class Recipe
	{
		public Recipe(string name,
			string description,
			ICollection<RecipeIngredient> recipeIngredients,
			RecipeDetails recipeDetails)
		{
			Id = new Id<Recipe>(Guid.NewGuid());
			Name = name;
			Description = description;
			RecipeIngredients = recipeIngredients;
			RecipeDetails = recipeDetails;
		}
		
		public Id<Recipe> Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
	}
}