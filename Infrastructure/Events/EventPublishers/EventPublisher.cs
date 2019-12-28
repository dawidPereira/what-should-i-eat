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
				var handlerType = typeof(IEventHandler<>).MakeGenericType( @event.GetType());
				var handlers = _serviceProvider.GetServices(handlerType).ToList();
				if (!handlers.Any())
					throw new InvalidOperationException(
						$"Event of type '{handlers.GetType()}' has not registered handler.");

				handlers.ForEach(x => Handle(@event));
				events.Dequeue();
			}
		}

		private static void Handle(object @event)
		{
			var handlerType = typeof(IEventHandler<>).MakeGenericType( @event.GetType());
			var methodInfo = handlerType.GetMethod("Handle");
			var handle = methodInfo?.MakeGenericMethod(@event.GetType());
			handle?.Invoke(null, new[] { @event });
		}
	}
}