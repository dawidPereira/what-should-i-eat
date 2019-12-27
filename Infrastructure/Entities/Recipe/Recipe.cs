using System;
using System.Collections.Generic;
using Domain.Recipes.Entities;

namespace Infrastructure.Entities.Recipe
{
	public sealed class Recipe
	{
		public Recipe(Guid id, string name, string description, RecipeInfo recipeInfo, ICollection<RecipeIngredient> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeInfo RecipeInfo { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
	}
}