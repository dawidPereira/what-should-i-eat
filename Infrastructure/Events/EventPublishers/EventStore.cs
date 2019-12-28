using System.Collections;
using System.Collections.Generic;
using Domain.Common.Mediators.Events;

namespace Infrastructure.Events.EventPublishers
{
	public class EventStore
	{
		private IDictionary<string, Queue> QueueDictionary { get; }

		public EventStore()
		{
			QueueDictionary = new Dictionary<string, Queue>();
		}

		public void AddEvent<T>(string queueName, IEvent<T> @event)
		{
			var queueExist = QueueDictionary.TryGetValue(queueName, out var queue);
			if(queueExist)
				queue.Enqueue(@event);
			else
			{
				QueueDictionary.Add(queueName, new Queue());
				QueueDictionary[queueName].Enqueue(@event);
			}
		}

		public Queue GetEvents(string queueName) => QueueDictionary[queueName];
	}
}