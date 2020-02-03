using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Entities.Recipe
{
	public sealed class Recipe
	{
		private Recipe() { }
		
		public Recipe(Guid id,
			string name,
			string description,
			string imageUrl,
			RecipeInfo recipeInfo,
			ICollection<RecipeIngredient> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			ImageUrl = imageUrl;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string ImageUrl { get; private set; }
		public RecipeInfo RecipeInfo { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
		
		public static Recipe FromDomainRecipe(Domain.Recipes.Entities.Recipe recipe) =>
			new Recipe(recipe.Id.Value,
				recipe.Name,
				recipe.Description,
				recipe.ImageUrl,
				RecipeInfo.FromDomainRecipeInfo(recipe.RecipeInfo),
				GetRecipeIngredients(recipe));

		private static ICollection<RecipeIngredient> GetRecipeIngredients(Domain.Recipes.Entities.Recipe recipe)
		{
			var recipeIngredientsCollection = recipe.RecipeIngredients;
			return recipeIngredientsCollection.Select(x =>  RecipeIngredient.FromDomainRecipe(recipe.Id.Value, x))
				.ToList();
		}
	}
}