using System;

namespace Domain.Events
{
	public abstract class EventMessage : IEventMessage
	{
		protected EventMessage(string message, string eventType)
		{
			Id = Guid.NewGuid();
			EventType = eventType;
			Message = message;
			CreatedDate = DateTime.Now;
		}

		public Guid Id { get; }
		public string EventType { get; }
		public string Message { get; }
		public DateTime CreatedDate { get; }


		public bool Equals(IEventMessage other)
		{
			return Id.Equals(other.Id) 
			       && EventType == other.EventType 
			       && Message == other.Message 
			       && CreatedDate.Equals(other.CreatedDate);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((EventMessage) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ (EventType != null ? EventType.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ CreatedDate.GetHashCode();
				return hashCode;
			}
		}
	}
}