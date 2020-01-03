using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Events;
using Domain.Events.Repositories;
using Infrastructure.Entities.Events;
using Infrastructure.Mappers.Events;
using Infrastructure.Repositories.DataAccess.Events;

namespace Infrastructure.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly IEventDataReader _eventDataReader;
		private readonly IEventDataWriter _eventDataWriter;
		private readonly IEventMapper _eventMapper;

		public EventRepository(IEventDataReader eventDataReader, IEventDataWriter eventDataWriter, IEventMapper eventMapper)
		{
			_eventDataReader = eventDataReader;
			_eventDataWriter = eventDataWriter;
			_eventMapper = eventMapper;
		}

		public void Add(EventMessage eventMessage) => _eventDataWriter.Add(OutboxEvent.FromEventMessage(eventMessage));

		public void RemoveById(Guid eventId)
		{
			var @event = _eventDataReader.GetEventById(eventId);
			_eventDataWriter.Remove(@event);
		}

		public IEnumerable<IEvent> GetEventsToProcess() => _eventDataReader.GetEventsToProcess()
			.Select(_eventMapper.FromOutboxEvent)
			.ToList();
	}
}