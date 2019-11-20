using System;
using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Extensions;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;
using WhatShouldIEat.Administration.Domain.Ingredients.Command;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	public class Ingredient
	{
		public Ingredient(string name,
			HashSet<Allergen> allergens,
			HashSet<Requirements> requirements,
			HashSet<Tuple<MacroNutrient, double>> macroNutrientsPerGram)
		{
			Name = name;
			Id = new Id<Ingredient>(Guid.NewGuid());
			SetAllergen(allergens);
			SetRequirements(requirements);
			SetMacroNutrients(macroNutrientsPerGram);
		}

		public string Name { get; set; }
		public Id<Ingredient> Id { get; private set; }
		public HashSet<Allergen> Allergens { get; private set; }
		public HashSet<Requirements> Requirements { get; private set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; set; }

		public double CalculateCalories(double grams) =>
			MacroNutrientsPerGram.Sum(x => x.Item1.CalculateCalories(x.Item2 * grams));

		public void Update(UpdateIngredientCommand command)
		{
			Name = command.Name;
			Allergens = command.Allergens;
			Requirements = command.Requirements;
			MacroNutrientsPerGram = command.MacroNutrients;
		}

		public void SetMacroNutrients(HashSet<Tuple<MacroNutrient, double>> macroNutrients)
		{
			macroNutrients.ForEach(x => x.Item2.ThrowExceptionIfLowerThanZero("Grams"));
			MacroNutrientsPerGram = macroNutrients;
		}

		public void SetAllergen(HashSet<Allergen> allergens) => Allergens = allergens ?? 
			            throw new ArgumentNullException(nameof(Requirements), ExceptionMessages.ValueCannotBeNull);

		public void SetRequirements(HashSet<Requirements> requirements) => Requirements = requirements ??
			            throw new ArgumentNullException(nameof(Requirements), ExceptionMessages.ValueCannotBeNull);

		public IngredientDto ToDto() =>
			new IngredientDto
			{
				Id = Id,
				Name = Name,
				Allergens = Allergens,
				Requirements = Requirements,
				MacroNutrientsPerGram = MacroNutrientsPerGram
			};
	}
}