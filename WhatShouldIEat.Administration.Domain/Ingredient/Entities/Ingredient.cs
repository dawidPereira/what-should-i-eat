using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Ingredient.Entities.MacroNutrints;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredient.Entities
{
	public class Ingredient
	{
		public Ingredient(string name,
			HashSet<Tuple<MacroNutrient, double>> macroNutrients,
			HashSet<Allergen> allergens,
			HashSet<Requirements> requirements)
		{
			Id = new Id<Ingredient>(Guid.NewGuid());
			Name = name;
			MacroNutrients = macroNutrients;
			Allergens = allergens;
			Requirements = requirements;
		}

		public Id<Ingredient> Id { get; private set; }
		public string Name { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrients { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }

		public double CalculateCalories() => MacroNutrients.Sum(x => x.Item1.CountCalorieFromMass(x.Item2));
	}
}