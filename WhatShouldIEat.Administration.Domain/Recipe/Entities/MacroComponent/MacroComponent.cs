namespace WhatShouldIEat.Administration.Domain.Recipe.Entities.MacroComponent
{
	public struct MacroComponent
	{
		public MacroComponent(double weight) => Weight = weight;
		public double Weight { get; private set; }
	}
}