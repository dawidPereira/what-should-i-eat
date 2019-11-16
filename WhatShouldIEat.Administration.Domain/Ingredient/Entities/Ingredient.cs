using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredient.Entities
{
	public class Ingredient
	{
		public Ingredient(string name,
			HashSet<MacroNutrient.MacroNutrient> macroNutrients,
			ICollection<Allergen> allergens,
			ICollection<Requirements> requirements)
		{
			Id = new Id<Ingredient>(Guid.NewGuid());
			Name = name;
			MacroNutrients = macroNutrients;
			Allergens = allergens;
			Requirements = requirements;
		}

		public Id<Ingredient> Id { get; private set; }
		public string Name { get; private set; }
		public HashSet<MacroNutrient.MacroNutrient> MacroNutrients { get; private set; }
		public ICollection<Allergen> Allergens { get; private set; }
		public ICollection<Requirements> Requirements { get; private set; }
	}
}