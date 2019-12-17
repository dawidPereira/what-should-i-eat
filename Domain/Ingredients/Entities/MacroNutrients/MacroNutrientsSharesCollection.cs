using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities.MacroNutrients
{
	public class MacroNutrientsSharesCollection : IValueObjectCollection<Share, MacroNutrientsSharesCollection>
	{
		private readonly HashSet<Share> _shares;

		public MacroNutrientsSharesCollection(IEnumerable<Share> shares) => 
			_shares = shares.ToHashSet();

		public IEnumerator<Share> GetEnumerator() => _shares.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public MacroNutrientsSharesCollection AddShare(Share share)
		{
			var shares = _shares.ToHashSet();
			shares.Add(share);
 
			return new MacroNutrientsSharesCollection(shares);
		}
		
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

		public override int GetHashCode() => (_shares != null ? _shares.GetHashCode() : 0);
	}
}