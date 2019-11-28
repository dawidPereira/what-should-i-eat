using System;
using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient
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