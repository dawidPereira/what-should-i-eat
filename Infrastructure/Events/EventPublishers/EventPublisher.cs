﻿using System;
 using System.Linq;
 using Domain.Events;
 using Domain.Events.Repositories;
 using Microsoft.Extensions.DependencyInjection;

 namespace Infrastructure.Events.EventPublishers
{
	public class EventPublisher : IEventPublisher
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IEventRepository _eventRepository;
		
		private EventQueue EventsQueue { get; }

		public EventPublisher(IServiceProvider serviceProvider, IEventRepository eventRepository)
		{
			_serviceProvider = serviceProvider;
			_eventRepository = eventRepository;
			EventsQueue = new EventQueue(eventRepository);
		}

		public void Publish(EventMessage eventMessage) => _eventRepository.Add(eventMessage);

		public void Rise()
		{
			while (EventsQueue.Count() > 0)
			{
				var @event = EventsQueue.Dequeue();
				HandleEvents(@event);
				_eventRepository.RemoveById(@event.EventId);
			}
		}
		
		private void HandleEvents<TEvent>(TEvent @event) where TEvent : IEvent
		{
			var handlers = _serviceProvider.GetServices(typeof(IEventHandler<>).MakeGenericType( @event.GetType()))
				.ToList();
			
			if (!handlers.Any())
				throw new InvalidOperationException(
					$"EventMessage of type '{@event.GetType()}' has not registered handler.");
			
			handlers.ForEach(x => Handle(@event, x));
		}

		private static void Handle(object @event, object eventHandler)
		{
			var handlerType = eventHandler.GetType();
			var methodInfo = handlerType.GetMethod("Handle");
			var handler = Activator.CreateInstance(handlerType);
			methodInfo?.Invoke(handler, new[] { @event });
		}
	}
}