using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Recipes.Dtos;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Commands.Update
{
	public class UpdateRecipeCommand : ICommand
	{
		public UpdateRecipeCommand(Guid id, string name, string description, RecipeInfo recipeInfo, IEnumerable<RecipeIngredientDto> recipeIngredients)
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
		public RecipeInfo RecipeInfo { get; }
		public IEnumerable<RecipeIngredientDto> RecipeIngredients { get; }
	}
}