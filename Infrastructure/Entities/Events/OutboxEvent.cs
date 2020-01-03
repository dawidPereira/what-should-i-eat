using System;
using Domain.Events;

namespace Infrastructure.Entities.Events
{
	public class OutboxEvent : IEventMessage
	{
		private OutboxEvent() { }
		private OutboxEvent(Guid id, string eventType, string message, DateTime createdDate)
		{
			Id = id;
			EventType = eventType;
			Message = message;
			CreatedDate = createdDate;
		}
		
		public Guid Id { get; private set; }
		
		public string EventType { get; private set;}
		
		public string Message { get; private set;}
		
		public DateTime CreatedDate { get; private set;}
		
		public static OutboxEvent FromEventMessage(IEventMessage eventMessage) => new OutboxEvent(
			eventMessage.Id, eventMessage.EventType, eventMessage.Message, eventMessage.CreatedDate);

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
			return obj.GetType() == GetType() && Equals((OutboxEvent) obj);
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