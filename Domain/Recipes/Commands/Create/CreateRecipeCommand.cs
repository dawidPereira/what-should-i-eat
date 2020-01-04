using System;
using System.Collections.Generic;
using Domain.Common.Mediators.Commands;
using Domain.Recipes.Dtos;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommand : ICommand
	{
		public CreateRecipeCommand(Guid id, string name, string description, RecipeInfo recipeInfo, IEnumerable<RecipeIngredientDto> recipeIngredients)
		{
			Id = id;
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		
		public Guid Id { get; private set;}
		public string Name { get; private set;}
		public string Description { get; private set;}
		public RecipeInfo RecipeInfo { get; private set;}
		public IEnumerable<RecipeIngredientDto> RecipeIngredients { get; private set;}
	}
}