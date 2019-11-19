using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command
{
	public class CreateIngredientCommand : ICommand
	{
		public string Name { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrients { get; private set; }
	}
}