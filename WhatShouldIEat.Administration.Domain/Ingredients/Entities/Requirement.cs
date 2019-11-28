using System;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities
{
	[Flags]
	public enum Requirement
	{
		None = 0,
		ForVegan = 1 << 1,
		ForVegetarian = 1 << 2,
		Ecological = 1 << 3
	}
}