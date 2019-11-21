using WhatShouldIEat.Administration.Domain.Common.ValueObjects;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Dto.IngredientsDto
{
	public class IngredientBasicInfo
	{
		public string Name { get; set; }
		public Id<Ingredient> Id { get; set; }
	}
}