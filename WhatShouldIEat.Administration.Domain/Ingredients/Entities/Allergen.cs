using System;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	[Flags]
	public enum Allergen
	{
		None = 0,
		Gluten = 1,
		Milk = 1 << 2,
		Nuts = 1 << 3
	}
}