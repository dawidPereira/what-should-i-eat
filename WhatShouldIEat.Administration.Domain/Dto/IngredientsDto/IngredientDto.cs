using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Dto.IngredientsDto
{
	public class IngredientDto
	{
		public string Name { get; set; }
		public Id<Ingredient> Id { get; set; }
		public HashSet<Allergen> Allergens { get; set; }
		public HashSet<Requirements> Requirements { get; set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; set; }
	}
}