﻿using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Dtos
{
	public class IngredientDto
	{
		public string Name { get; set; }
		public Guid Id { get; set; }
		public HashSet<Allergen> Allergens { get; set; }
		public HashSet<Requirements> Requirements { get; set; }
		public HashSet<Tuple<MacroNutrient, double>> MacroNutrientsPerGram { get; set; }
	}
}