using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.MacroComponent
{
	public class Ingredient
	{
		public Ingredient(string name,
			MacroComponents macroComponents,
			ICollection<Allergen> allergens,
			ICollection<Requirements> requirements)
		{
			Id = new Id<Ingredient>(Guid.NewGuid());
			Name = name;
			MacroComponents = macroComponents;
			Allergens = allergens;
			Requirements = requirements;
		}

		public Id<Ingredient> Id { get; private set; }
		public string Name { get; private set; }
		public MacroComponents MacroComponents { get; private set; }
		public ICollection<Allergen> Allergens { get; private set; }
		public ICollection<Requirements> Requirements { get; private set; }
	}
}