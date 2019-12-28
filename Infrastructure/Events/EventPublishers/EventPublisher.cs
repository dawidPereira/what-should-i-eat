﻿using System;
 using System.Linq;
 using Domain.Common.Mediators.Events;
 using Microsoft.Extensions.DependencyInjection;

 namespace Infrastructure.Events.EventPublishers
{
	public class EventPublisher : IEventPublisher
	{
		private readonly IServiceProvider _serviceProvider;
		private EventStore EventsStore { get; }

		public EventPublisher(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			EventsStore = new EventStore();
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent<TEvent> 
			=> EventsStore.AddEvent(@event.EventIdentity.QueueName, @event);

		public void Rise(string queueName)
		{
			var events = EventsStore.GetEvents(queueName);
			foreach (var @event in events)
			{
				var genericType = typeof(IEventHandler<>).MakeGenericType( @event.GetType());
				var handlers = _serviceProvider.GetServices(genericType).ToList();
				if (!handlers.Any())
					throw new InvalidOperationException(
						$"Event of type '{handlers.GetType()}' has not registered handler.");

				handlers.ForEach(x => Handle(@event));
				events.Dequeue();
			}
		}

		private static void Handle(object @event)
		{
			var genericType = typeof(IEventHandler<>).MakeGenericType( @event.GetType());
			var mi = genericType.GetMethod("Handle");
			var mi2 = mi?.MakeGenericMethod(@event.GetType());
			mi2?.Invoke(null, new object[] { @event });
		}
	}
}