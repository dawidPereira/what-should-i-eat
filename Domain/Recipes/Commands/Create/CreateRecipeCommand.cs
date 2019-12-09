using System;
using System.Collections.Generic;
using Domain.Mediators.Command;
using Domain.Recipes.Entities;

namespace Domain.Recipes.Commands.Create
{
	public class CreateRecipeCommand : ICommand
	{
		public Guid Id { get;  set; }
		public string Name { get;  set; }
		public string Description { get;  set; }
		public RecipeDetails RecipeDetails { get;  set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get;  set; }
	}
}