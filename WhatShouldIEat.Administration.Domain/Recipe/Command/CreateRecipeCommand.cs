using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipe.Entities.Recipe;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command
{
	public class CreateRecipeCommand : ICommand
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int DifficultyLevel { get; set; }
		public int PreparationTime { get; set; }
		public decimal ApproximateCost { get; set; }
		public ICollection<MealType> MealTypes { get; set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
	}
}