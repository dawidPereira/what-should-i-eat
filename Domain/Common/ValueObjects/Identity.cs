using System;
using System.Collections.Generic;

namespace Domain.Common.ValueObjects
{
	public struct Identity<T> : IValueObject<Identity<T>>
	{
		public Identity(T value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(T),"Id can not be null or empty.");
			Value = value;
		}

		public T Value { get; }

		public bool Equals(Identity<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj.GetType() == GetType() && Equals((Identity<T>) obj);
		}

		public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);
	}
}