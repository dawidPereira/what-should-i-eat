using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Command
{
	public class CreateRecipeCommand : ICommand
	{
		public Id<Entities.Recipe.Recipe> Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int DifficultyLevel { get; set; }
		public int PreparationTime { get; set; }
		public decimal ApproximateCost { get; set; }
		public ICollection<int> MealTypes { get; set; }
		public ICollection<Tuple<string, double>> RecipeIngredients { get; set; }
	}
}