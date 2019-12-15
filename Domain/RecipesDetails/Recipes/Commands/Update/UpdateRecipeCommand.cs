using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.RecipesDetails.Recipes.Entities;

namespace Domain.RecipesDetails.Recipes.Commands.Update
{
	public class UpdateRecipeCommand : ICommand
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public RecipeDetails RecipeDetails { get; set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
	}
}