using System;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients
{
	[Flags]
	public enum MacroNutrient
	{
		None = 0,
		[MacroNutrient(4)] Carbohydrate = 1 << 1,
		[MacroNutrient(9)] Fat = 1 << 2,
		[MacroNutrient(4)] Protein = 1 << 3
	}
}