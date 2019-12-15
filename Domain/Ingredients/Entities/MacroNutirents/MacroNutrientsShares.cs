using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities.MacroNutirents
{
	public class MacroNutrientsShares : IValueObject, IEnumerable<Share>, IEquatable<MacroNutrientsShares>
	{
		private readonly HashSet<Share> _shares;

		public MacroNutrientsShares(HashSet<Share> participants) => 
			_shares = participants;

		public IEnumerator<Share> GetEnumerator() => _shares.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public MacroNutrientsShares AddShare(Share share)
		{
			var shares = _shares.ToHashSet();
			shares.Add(share);
 
			return new MacroNutrientsShares(shares);
		}
		public bool Equals(MacroNutrientsShares other)
		{
			if (ReferenceEquals(null, other)) return false;
			return ReferenceEquals(this, other) || Equals(_shares, other._shares);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == this.GetType() && Equals((MacroNutrientsShares) obj);
		}

		public override int GetHashCode() => (_shares != null ? _shares.GetHashCode() : 0);
	}
}