using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommand : ICommand
	{
		public CreateRecipeCommand(Guid id, string name, string description, RecipeInfo recipeInfo, ICollection<RecipeIngredient> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public RecipeInfo RecipeInfo { get; set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
	}
}