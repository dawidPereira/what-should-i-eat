using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Domain.Common.Events;

namespace WhatShouldIEat.Administration.Infrastructure.Events.EventPublishers
{
	public class EventPublisher : IEventPublisher
	{
		private readonly IServiceProvider _serviceProvider;

		public EventPublisher(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
		{
			var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
			var eventHandlers = handlers.ToList();
			if (!eventHandlers.Any())
				throw new InvalidOperationException(
					$"Event of type '{handlers.GetType()}' has not registered handler.");

			eventHandlers.ForEach(x => x.Handle(@event));
		}
	}
}