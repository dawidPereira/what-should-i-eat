﻿using System;
 using System.Linq;
 using System.Threading.Tasks;
 using Domain.Events;
 using Domain.Events.Repositories;
 using Microsoft.Extensions.DependencyInjection;

 namespace Infrastructure.Events.EventPublishers
{
	public class EventPublisher : IEventPublisher
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IEventRepository _eventRepository;

		public EventPublisher(IServiceProvider serviceProvider, IEventRepository eventRepository)
		{
			_serviceProvider = serviceProvider;
			_eventRepository = eventRepository;

		}

		public async Task Publish(EventMessage eventMessage) => await _eventRepository.Add(eventMessage);

		public void Rise()
		{
			var eventQueue = new EventQueue(_eventRepository);
			while (eventQueue.Count() > 0)
			{
				var @event = eventQueue.Dequeue();
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

		private void Handle(object @event, object eventHandler)
		{
			var handlerType = eventHandler.GetType();
			var methodInfo = handlerType.GetMethod("Handle");
			methodInfo?.Invoke(eventHandler, new[] { @event });
		}
	}
}
