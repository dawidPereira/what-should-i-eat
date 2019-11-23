﻿using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Message;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands;
using WhatShouldIEat.Administration.Domain.Ingredients.Dtos;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class Ingredient
	{
		public Ingredient(Guid id,
			string name,
			HashSet<Allergen> allergens,
			HashSet<Requirements> requirements,
			HashSet<Tuple<MacroNutrient, double>> macroNutrientsPerGram)
		{
			Name = name;
			Id = id;
			SetAllergen(allergens);
			SetRequirements(requirements);
			SetMacroNutrients(macroNutrientsPerGram);
		}

		public string Name { get; set; }
		public Guid Id { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; private set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

		public double CalculateCalories(double grams) =>
			MacroNutrientsPerGram.Sum(x => x.Item1.CalculateCalories(x.Item2 * grams));

		public void SetMacroNutrients(HashSet<Tuple<MacroNutrient, double>> macroNutrients)
		{
			macroNutrients.ForEach(x => x.Item2.ThrowExceptionIfLowerThanZero("Grams"));
			MacroNutrientsPerGram = macroNutrients;
		}

		public void SetAllergen(HashSet<Allergen> allergens) => Allergens = allergens ?? 
			            throw new ArgumentNullException(nameof(Requirements), ExceptionMessages.ValueCannotBeNull);

		public void SetRequirements(HashSet<Requirements> requirements) => Requirements = requirements ??
			            throw new ArgumentNullException(nameof(Requirements), ExceptionMessages.ValueCannotBeNull);

		public void Update(UpdateIngredientCommand command)
		{
			Name = command.Name;
			Allergens = command.Allergens;
			Requirements = command.Requirements;
			MacroNutrientsPerGram = command.MacroNutrients;
		}

		public IngredientDto ToDto() => new IngredientDto 
		{
			Id = Id,
			Name = Name,
			Allergens = Allergens,
			Requirements = Requirements,
			MacroNutrientsPerGram = MacroNutrientsPerGram
		};
	}
}