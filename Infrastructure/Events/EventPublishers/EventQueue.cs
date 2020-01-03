using System.Collections.Generic;
using System.Linq;
using Domain.Common.Extensions;
using Domain.Events;
using Domain.Events.Repositories;

namespace Infrastructure.Events.EventPublishers
{
	public class EventQueue
	{
		private readonly IEventRepository _eventRepository;
		private Queue<IEvent> EventsQueue { get; }

		public EventQueue(IEventRepository eventRepository)
		{
			_eventRepository = eventRepository;
			EventsQueue = new Queue<IEvent>();
			Enqueue();
		}

		public int Count() => EventsQueue.Count;

		public IEvent Dequeue() => EventsQueue.Dequeue();

		private void Enqueue()
		{
			_eventRepository.GetEventsToProcess()
				.OrderByDescending(x => x.CreatedDate)
				.ForEach(EventsQueue.Enqueue);
		}
	}
}