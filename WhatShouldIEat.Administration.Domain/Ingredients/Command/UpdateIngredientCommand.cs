using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Command
{
	public class UpdateIngredientCommand : ICommand
	{
		public Id<Ingredient> Id { get; set; }
		public string Name { get;  set; }
		public HashSet<Allergen> Allergens { get;  set; }
		public HashSet<Requirements> Requirements { get;  set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrients { get;  set; }
	}
}