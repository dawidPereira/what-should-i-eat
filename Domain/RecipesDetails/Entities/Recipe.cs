using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Entities
{
	public struct Recipe
	{
		public Recipe(Guid id, string name, string description, RecipeInfo recipeInfo, IDictionary<Guid, double> recipeIngredients)
		{
			Id = new Identity<Guid>(id);
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		public Identity<Guid> Id { get; }
		public string Name { get; }
		public string Description { get; }
		public RecipeInfo RecipeInfo { get; }
		public IDictionary<Guid, double> RecipeIngredients { get; }
	}
}