using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class Ingredient
	{
		public Ingredient(string name,
			HashSet<Tuple<MacroNutrient, double>> macroNutrientsPerGram,
			HashSet<Allergen> allergens,
			HashSet<Requirements> requirements)
		{
			Id = new Id<Ingredient>(Guid.NewGuid());
			Name = name;
			SetMacroNutrients(macroNutrientsPerGram);
			Allergens = allergens;
			Requirements = requirements;
		}

		public Id<Ingredient> Id { get; private set; }
		public string Name { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }

		public double CalculateCalories(double grams) =>
			MacroNutrientsPerGram.Sum(x => x.Item1.CalculateCalories(x.Item2 * grams));

		public void SetMacroNutrients(HashSet<Tuple<MacroNutrient, double>> macroNutrients)
		{
			macroNutrients.ForEach(x => x.Item2.ThrowExceptionIfLowerThanZero());
			MacroNutrientsPerGram = macroNutrients;
		}
	}
}