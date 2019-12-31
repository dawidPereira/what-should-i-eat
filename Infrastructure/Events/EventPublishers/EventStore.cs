using System.Collections.Generic;
using Domain.Events;

namespace Infrastructure.Events.EventPublishers
{
	public class EventStore
	{
		private Queue<Event> EventsQueue { get; }

		public EventStore()
		{
			EventsQueue = new Queue<Event>();
		}

		public void AddEvent(Event @event)
		{
			EventsQueue.Enqueue(@event);
		}

		public Queue<Event> GetEvents() => EventsQueue;
	}
}