using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities.MacroNutrients
{
	public class MacroNutrientsSharesCollection : IValueObjectCollection<MacroNutrientShare, MacroNutrientsSharesCollection>
	{
		private readonly HashSet<MacroNutrientShare> _shares;

		public MacroNutrientsSharesCollection(IEnumerable<MacroNutrientShare> shares) =>
			_shares = SetShares(shares);

		public IEnumerator<MacroNutrientShare> GetEnumerator() => _shares.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool Equals(MacroNutrientsSharesCollection other)
		{
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || Equals(_shares, other._shares);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((MacroNutrientsSharesCollection) obj);
		}

		public override int GetHashCode() => _shares != null ? _shares.GetHashCode() : 0;

		private HashSet<MacroNutrientShare> SetShares(IEnumerable<MacroNutrientShare> shares)
		{
			var aggregatedShares = shares.Aggregate(0d, (acc, ell) => acc + ell.Share);
			if(aggregatedShares < 0 && aggregatedShares > 1)
				throw new ArgumentOutOfRangeException(nameof(MacroNutrientsSharesCollection), 
					$"Sum of shares must be lower or equal one. It was {aggregatedShares}.");
			return shares.ToHashSet();
		}
	}
}