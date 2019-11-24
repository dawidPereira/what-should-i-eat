using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Recipes.Commands.Update
{
	public class UpdateRecipeCommand : ICommand
	{
		public Guid Id { get;  set; }
		public string Name { get;  set; }
		public string Description { get;  set; }
		public RecipeDetails RecipeDetails { get;  set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get;  set; }
	}
}