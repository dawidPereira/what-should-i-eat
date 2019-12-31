using System.Collections.Generic;
using Domain.Events;
using Domain.Events.Repositories;
using Infrastructure.Repositories.DataAccess.Events;

namespace Infrastructure.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly IEventDataReader _eventDataReader;
		private readonly IEventDataWriter _eventDataWriter;

		public EventRepository(IEventDataReader eventDataReader, IEventDataWriter eventDataWriter)
		{
			_eventDataReader = eventDataReader;
			_eventDataWriter = eventDataWriter;
		}

		public void AddEvent(Event @event) => _eventDataWriter.Add(@event);

		public void RemoveEvent(Event @event) => _eventDataWriter.Remove(@event);
		
		public IEnumerable<Event> GetEventsToProcess() => _eventDataReader.GetEventsToProcess();
	}
}