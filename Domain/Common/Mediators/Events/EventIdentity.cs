using System;

namespace Domain.Common.Mediators.Events
{
	public class EventIdentity : IEventIdentity, IEquatable<EventIdentity>
	{
		public EventIdentity(string queueName)
		{
			Id = Guid.NewGuid();
			QueueName = queueName;
		}
		
		public Guid Id { get; }
		public string QueueName { get; }

		public bool Equals(EventIdentity other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id.Equals(other.Id) && QueueName == other.QueueName;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((EventIdentity) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Id.GetHashCode() * 397) ^ (QueueName != null ? QueueName.GetHashCode() : 0);
			}
		}
	}
}