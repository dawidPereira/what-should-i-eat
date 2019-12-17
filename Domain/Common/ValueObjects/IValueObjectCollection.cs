using System;
using System.Collections.Generic;

namespace Domain.Common.ValueObjects
{
	public interface IValueObjectCollection<out TItem, TCollection> : IEnumerable<TItem>, IEquatable<TCollection>
	{
	}
}