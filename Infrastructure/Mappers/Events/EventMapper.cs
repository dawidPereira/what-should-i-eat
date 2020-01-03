using System;
using System.Linq;
using System.Reflection;
using Domain.Events;
using Infrastructure.Entities.Events;

namespace Infrastructure.Mappers.Events
{
	public class EventMapper : IEventMapper
	{
		public IEvent FromOutboxEvent(OutboxEvent @event)
		{
			var assembly = Assembly.GetAssembly(typeof(IEvent));
			var eventType = assembly.GetTypes()
				.FirstOrDefault(x => x.Name == @event.EventType)
			                ?? throw new ArgumentNullException(nameof(@event.EventType), $"Cannot find EventType for event with Id: {@event.Id}.");
			
			return (IEvent)eventType.GetMethod("CreateFromMessage")?.Invoke(null, new object []{@event.Id, @event.CreatedDate, @event.Message}); 
		}
		
	}
}