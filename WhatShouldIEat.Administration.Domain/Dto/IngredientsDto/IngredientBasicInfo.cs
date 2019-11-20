using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Dto.IngredientsDto
{
	public class IngredientBasicInfo
	{
		public string Name { get; set; }
		public Id<Ingredient> Id { get; set; }
	}
}