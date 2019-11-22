using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command
{
	public class UpdateRecipeCommand : ICommand
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public RecipeDetails RecipeDetails { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
	}
}