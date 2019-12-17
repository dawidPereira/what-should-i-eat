using System;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Events
{
	public class EventIdentity : IEventIdentity, IEquatable<EventIdentity>
	{
		public EventIdentity(string queueName)
		{
			Id = new Identity<Guid>(Guid.NewGuid());
			QueueName = queueName;
		}
		
		public Identity<Guid> Id { get; }
		public string QueueName { get; }

		public bool Equals(EventIdentity other) => !ReferenceEquals(null, other) && Id.Equals(other.Id);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((EventIdentity) obj);
		}

		public override int GetHashCode() => Id.GetHashCode();
	}
}