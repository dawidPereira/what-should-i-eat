using System;

namespace Domain.Common.Mediators.Events
{
	public interface IEvent<T> : IEquatable<T>
	{
		IEventIdentity EventIdentity { get; }
	}
}