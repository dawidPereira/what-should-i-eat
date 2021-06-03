using System;

namespace Domain.Ingredients.Entities
{
	[Flags]
	public enum Allergen
	{
		None = 0,
		Milk = 1 << 1,
		Eggs = 1 << 2,
		Wheat = 1 << 3,
		Shellfish = 1 << 4,
		Soy = 1 << 5,
		Nuts = 1 << 6,
		Gluten = 1 << 7
	}
}
