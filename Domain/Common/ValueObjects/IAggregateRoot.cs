using System;

namespace Domain.Common.ValueObjects
{
	public interface IAggregateRoot<TAggregate, TIdentity> : IEquatable<TAggregate>
	{
		Identity<TIdentity> Id { get; }
	}
}