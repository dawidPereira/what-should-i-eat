﻿using System;
using System.Collections.Generic;
using Domain.Ingredients.Entities;

namespace Domain.Ingredients.Queries.GetIngredient
{
	public class IngredientDto
	{
		public string Name { get; set; }
		public Guid Id { get; set; }
		public Allergen Allergens { get; set; }
		public Requirement Requirements { get; set; }
		public ICollection<IngredientMacroNutrient> MacroNutrientsParticipation { get; set; }
	}
}