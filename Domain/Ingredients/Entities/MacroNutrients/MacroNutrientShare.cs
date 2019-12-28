using System;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities.MacroNutrients
{
	public struct MacroNutrientShare : IValueObject<MacroNutrientShare>
	{
		public MacroNutrientShare(MacroNutrient macroNutrient, double share)
		{
			MacroNutrient = macroNutrient;
			Share = SetShare(share);
		}

		public MacroNutrient MacroNutrient { get; }
		public double Share { get; }

		public bool Equals(MacroNutrientShare other) =>
			MacroNutrient == other.MacroNutrient && Share.Equals(other.Share);

		public override bool Equals(object obj) =>
			obj is MacroNutrientShare other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((int) MacroNutrient * 397) ^ Share.GetHashCode();
			}
		}

		private static double SetShare(double share)
		{
			if (share <= 0 || share > 1)
				throw new ArgumentException(
					$"MacroNutrientShare must be in range 0 and 1. It was {share}.");

			return share;
		}
	}
}